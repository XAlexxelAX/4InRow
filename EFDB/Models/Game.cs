using System;
using System.Collections.Generic;
using System.Text;

namespace EFDB.Models
{
    public class Game
    {
        
        public int Id { get; set; }
        public int Player1 { get; set; }
        public int Player1Score { get; set; }
        public int Player2 { get; set; }
        public int Player2Score { get; set; }

        public int WinnerId { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
