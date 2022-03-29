using System;
using System.Linq;

namespace firstEFApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {

                // отношение один к одному

                var user1 = new User { Id = "1", Name = "Artur", Role = "Admin" };
                var user2 = new User { Id = "2", Name = "Bob", Role = "Admin" };
                var user3 = new User { Id = "3", Name = "Clack", Role = "User" };
                var user4 = new User { Id = "4", Name = "Dan", Role = "User" };

                db.Users.AddRange(user1, user2, user3, user4);
                
                db.SaveChanges();

                var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
                var user2Creds = new UserCredential { Login = "Bobj", Password = "asdfgh585" };
                var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
                var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };

                // Связать объекты сущноностей User и UserCredential 
                user1Creds.User = user1;
                user2Creds.UserId = user2.Id;
                user3.UserCredential = user3Creds;
                user4.UserCredential = user4Creds;

                db.UserCredentials.AddRange(user1Creds, user2Creds, user3Creds, user4Creds);

                db.SaveChanges();


                // один ко многим





                //var user1 = new User { Id = "1", Name = "Arthur", Role = "Admin" };
                //var user2 = new User { Id = "2", Name = "Klim", Role = "User" };
                //var user3 = new User { Id = "3", Name = "Bruce", Role = "User" };
                //var user4 = new User { Id = "4", Name = "Rust", Role = "User" };

                //db.Users.Add(user1);
                // db.Users.Add(user2);

                // db.Users.AddRange(user3, user4);

                //db.SaveChanges();

                //db.Users.RemoveRange(user1, user2, user3, user4);

                // Еще один способ удаления записи из таблицы бд
                // db.Entry(user3).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                // db.SaveChanges();

                // Выбор всех пользователей
                // var allUsersd = db.Users.ToList();

                // // Выбор пользователей с ролью "Admin"
                //// var admins = db.Users.Where(user => user.Role == "Admin").ToList();

                // foreach (var item in allUsersd)
                // {
                //     Console.WriteLine(item.Name);
                // }

                // // Изменение поля записи
                // var firstUser = db.Users.FirstOrDefault();

                // firstUser.Email = "simpleemail@gmail.com";
                // db.SaveChanges();

                // allUsersd = db.Users.ToList();

                // foreach (var item in allUsersd)
                // {
                //     Console.WriteLine(item.Email);
                // }

            }
        }
    }
}
