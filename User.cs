﻿namespace FinalProjectADO.Net1
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public ICollection<UserBook> UserBooks { get; set; }
    }
}


