using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using grpc4InRowService.Protos;

namespace connectFour
{
    /// <summary>
    /// Interaction logic for OnlineUsersList.xaml
    /// </summary>
    public partial class OnlineUsersList : Window
    {
        private GrpcChannel channel;
        private User.UserClient userClient;
        private Games.GamesClient gameClient;
        private System.Windows.Controls.Button lb_itemBtn;
        private Timer timerResponse;
        private int timerCount;
        private MyMsgBox msgBoxWindow;
        private bool isFree;
        public static Game game;
        private List<System.Windows.Controls.Button> userBtns;
        public OnlineUsersList()
        {
            InitializeComponent();

            try
            {
                channel = GrpcChannel.ForAddress("https://localhost:5001");
                userClient = new User.UserClient(channel);
                gameClient = new Games.GamesClient(channel);

                timerCount = 0;
                isFree = true;
                userBtns = new List<System.Windows.Controls.Button>();

                fillListAsync();
                InitTimer();
            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
                return;
            }
        }

        public void InitTimer()
        { // timer invokes each second
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 3000; // listen and update each second
            timer.Start();
        }
        public void InitTimer2()
        { // timer invokes each second
            timerResponse = new Timer();
            timerResponse.Tick += new EventHandler(timer_Tick2);
            timerResponse.Interval = 1000; // listen and update each second
            timerResponse.Start();
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                fillListAsync();
                if (!isFree)
                    return;

                CheckReply cr = await gameClient.CheckForGameAsync(new Check
                {
                    MyId = LoginPage.myID
                });

                if (isFree && cr.Answer && cr.Status == AnswerCode.Unanswered) // if there exist a request for game
                {
                    isFree = false;
                    var result = AutoClosingMessageBox.Show(
                        caption: LoginPage.myUsername + "- New Request Incoming!",
                        text: "Do you want to play?\nYou have 10 seconds to answer...",
                        timeout: 9000,
                        buttons: MessageBoxButtons.YesNo,
                        defaultResult: System.Windows.Forms.DialogResult.No); // SET DEFAULT TO 'NO' (if player hasn't repsond)

                    GameRequest gr = new GameRequest
                    {
                        MyId = cr.Offeringid,
                        OpponentID = LoginPage.myID
                    };
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        gr.Answer = AnswerCode.Accepted;
                        await userClient.RemoveFromOnlineAsync(new GeneralReq { Id = LoginPage.myID });
                        if (game == null)
                        {
                            game = new Game(false, LoginPage.myID, cr.Offeringid);
                            game.Closed += (sender, args) => { game = null; isFree = true; };
                            game.Show();
                        }
                    }
                    else
                    {
                        gr.Answer = AnswerCode.Rejected;
                        isFree = true;
                    }
                    await gameClient.OfferGameAsync(gr);
                }
            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
                return;
            }
        }

        private async void timer_Tick2(object sender, EventArgs e)
        { // check for answer/response of the game offer
            if (timerCount == 0 && msgBoxWindow != null)
                msgBoxWindow.Show();

            timerCount++;

            try
            {
                if (timerCount == 10)
                {
                    timerResponse.Stop();
                    if (msgBoxWindow != null)
                        msgBoxWindow.Close();
                    timerCount = 0;
                    await gameClient.RemoveRequestAsync(new GameRequest { OpponentID = (int)lb_itemBtn.DataContext });
                    System.Windows.MessageBox.Show("Your opponent didn't responed to your game request.");
                    return;
                }

                CheckReply cr = await gameClient.CheckForGameAsync(new Check { OpponentID = (int)lb_itemBtn.DataContext });
                if (cr.Answer)
                {
                    if (cr.Status == AnswerCode.Unanswered)
                        return;
                    else if (cr.Status == AnswerCode.Accepted)
                    {
                        timerResponse.Stop();
                        if (msgBoxWindow != null)
                            msgBoxWindow.Close();
                        timerCount = 0;
                        await userClient.RemoveFromOnlineAsync(new GeneralReq { Id = LoginPage.myID });
                        await gameClient.CreateGameAsync(new MoveRequest { InitiatorID = (int)lb_itemBtn.DataContext, InitiatedID = LoginPage.myID });
                        if (game == null)
                        {
                            game = new Game(true, (int)lb_itemBtn.DataContext, LoginPage.myID);
                            game.Closed += (sender, args) => { game = null; isFree = true; };
                            game.Show();
                        }
                    }
                    else
                    {
                        timerResponse.Stop();
                        if (msgBoxWindow != null)
                            msgBoxWindow.Close();
                        timerCount = 0;
                        await gameClient.RemoveRequestAsync(new GameRequest { OpponentID = (int)lb_itemBtn.DataContext });
                        System.Windows.MessageBox.Show("Your opponent denied the game request.");
                    }
                }
            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
                return;
            }
        }

        private async Task fillListAsync()
        {
            foreach (ListBoxItem user in users.Items)
                user.DataContext = false;

            try
            {
                using (var call = userClient.getOnlineUsers(new GeneralReq()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        if (call.ResponseStream.Current.Username.Equals(LoginPage.myUsername)) // skip 'my own' (this logged in user) username
                            continue;

                        bool isUserExist = false;
                        foreach (ListBoxItem user in users.Items) // check if current online user exist in list
                            if (((System.Windows.Controls.Button)user.Content).Content.Equals(call.ResponseStream.Current.Username))
                            {
                                isUserExist = true;
                                user.DataContext = true; // mark this user as online right now
                                break;
                            }
                        if (!isUserExist)
                        { // Add user if he online but doesn't exist in the list
                            ListBoxItem newUser = new ListBoxItem();
                            newUser.DataContext = true;
                            System.Windows.Controls.Button newUserBtn = new System.Windows.Controls.Button();
                            newUserBtn.Content = call.ResponseStream.Current.Username;
                            newUserBtn.Click += new RoutedEventHandler(userSelected);
                            newUser.Content = newUserBtn;
                            newUser.Focusable = false;
                            newUserBtn.DataContext = call.ResponseStream.Current.Id;
                            userBtns.Add(newUserBtn);
                            users.Items.Add(newUser);
                        }
                    }
                }

                foreach (ListBoxItem user in users.Items)
                    if (!(bool)user.DataContext) // if this user isn't online now
                    {// then remove him from online list
                        userBtns.Remove((System.Windows.Controls.Button)user.Content); // remove content (button inside list box item)
                        users.Items.Remove(user); // remove fully the list box item
                    }

            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
            }
        }

        private async void userSelected(object sender, RoutedEventArgs e)
        {
            if (timerCount > 0 || game != null) // if another request is in the process of waiting for an answer
                                                //or if a game is running then you wont be able to send requests
                return; // then dont allow another request to send

            lb_itemBtn = (System.Windows.Controls.Button)sender;

            try
            {
                GameReply gr = await gameClient.OfferGameAsync(new GameRequest
                {
                    MyId = LoginPage.myID,
                    OpponentID = (int)lb_itemBtn.DataContext,
                    Answer = AnswerCode.Unanswered
                });
                if (msgBoxWindow == null)
                {
                    msgBoxWindow = new MyMsgBox("Waiting for " + lb_itemBtn.Content + " reply\n10 seconds until closing...");
                    msgBoxWindow.Closed += (sender, args) => msgBoxWindow = null;
                }
                InitTimer2(); // invoke and check for answer
            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
            }
        }

        private void dataSearch(object sender, RoutedEventArgs e)
        {
            new DataSearch().Show();
        }

        public async void OnWindowClosing(object sender, CancelEventArgs e)
        {
            try
            {
                //sign out of the current user and update online users list in the server           
                await userClient.RemoveFromOnlineAsync(new GeneralReq { Id = LoginPage.myID });
            }
            catch (Grpc.Core.RpcException)
            {
                System.Windows.MessageBox.Show("An error from server has occurred", "Error");
            }
        }
    }
}
