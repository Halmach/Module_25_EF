using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstEFApp
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы UserCredentials
        public DbSet<UserCredential> UserCredentials { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();   // удаление старых таблиц для создания новых связей
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =DESKTOP-45Q7VOT\SQLEXPRESS01;DataBase =EF;Trusted_Connection=True;TrustServerCertificate=true; ");
        }
    }
}
