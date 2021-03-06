using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDB.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Key]
        public string Username { get; set; }
        public string PW { get; set; }
        public int Score { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
    }
}
