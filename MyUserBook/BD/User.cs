using System;

namespace MyUserBook.BD
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateTime { get; set; }  
    }
}