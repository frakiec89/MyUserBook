using System;

namespace MyUserBook.Model
{
    [Serializable]
    public class Log
    {
        public int Id { get; set; }
        public string LoginBad { get; set; }
        public string PasswordBad { get; set; }
        public User UserTry { get; set; }
        public bool Status { get; set; }
        public DateTime DateTime { get; set; }

        private Log ()
        {
            DateTime = DateTime.Now;
            LoginBad =String.Empty;
            PasswordBad =String.Empty;  
        }

        /// <summary>
        /// Успешный вход
        /// </summary>
        /// <param name="userTry"></param>
        public Log( User userTry) : this ()
        {
            UserTry = userTry;
            Status = true;
        }

        /// <summary>
        /// неудачный вход
        /// </summary>
        /// <param name="loginBad"></param>
        /// <param name="passwordBad"></param>
        public Log(string loginBad, string passwordBad) : this()
        {
            LoginBad = loginBad;
            PasswordBad = passwordBad;
            Status = false;
        }

    }
}