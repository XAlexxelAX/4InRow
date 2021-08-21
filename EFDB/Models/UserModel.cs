using System;
using System.Collections.Generic;
using System.Text;

namespace EFDB.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PW { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Score { get; set; }
    }
}
