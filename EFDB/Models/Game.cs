using System;
using System.Collections.Generic;
using System.Text;

namespace EFDB.Models
{
    public class Game
    {
        
        public int Id { get; set; }
        public List<UserModel> Players { get; set; } = new List<UserModel>();
        public int WinnerIndex { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
