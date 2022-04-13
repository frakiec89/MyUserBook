using MyUserBook.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyUserBook.Controller
{
    public class UserController
    {
        public List<Model.User> Users { get;  private set; }

        public UserController ()
        {
            Users = Run();
        }

        private List<User> Run()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                    var us = formatter.Deserialize(fs);
                    if (us != null)
                    {
                        return us as List<User>;
                    }
                    else
                        return new List<User>();
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }


        public void AddUser (string login , string password)
        {
            int id = 0;

            if(Users.Count>0)
            {
                id = Users.Max(x => x.UserId);
            }

            id++;

            Users.Add(new Model.User { Login = login, Password = password  , UserId= id});
            Save();
        }

        public void Save ()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                     formatter.Serialize(fs , Users);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
