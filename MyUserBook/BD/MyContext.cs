using Microsoft.EntityFrameworkCore;
using System;


namespace MyUserBook.BD
{
    public class MyContext :DbContext
    {
        private static string sc = "Server=192.168.10.134; database=Ahtymov_12_04_is_20_03; User id=stud; password=stud;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sc);
        }


        public DbSet<User> Users { get; set; }


    }
}
