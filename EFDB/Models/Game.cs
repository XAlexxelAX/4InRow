using System;
using System.Collections.Generic;
using System.Text;

namespace EFDB.Models
{
    public class Game
    {
        public List<User> Players { get; set; } = new List<User>();
        public int WinnerIndex { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
