using System;
using System.Linq;

namespace firstEFApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserLinq();
        }

        static void MainOperationOfEF()
        {
            using (var db = new AppContext())
            {

                // многие ко многим

                var company1 = new Company { Name = "SF" };
                var company2 = new Company { Name = "VK" };

                var company3 = new Company { Name = "FB" };

                db.Companies.AddRange(company1, company2, company3);
                db.SaveChanges();



                var topic1 = new Topic { Name = "Topic1" };
                var topic2 = new Topic { Name = "Topic2" };

                db.Topics.AddRange(topic1, topic2);


                var user1 = new User { Name = "Artur", Role = "Admin" };
                var user2 = new User { Name = "Bob", Role = "Admin" };
                var user3 = new User { Name = "Clack", Role = "User" };
                // var user4 = new User { Id = "4", Name = "Dan", Role = "User" };

                user1.Company = company1;
                company2.Users.Add(user2);
                user3.CompanyId = company3.Id;


                db.Users.AddRange(user1, user2, user3);

                user1.Topics.Add(topic1);
                user2.Topics.Add(topic2);
                user3.Topics.Add(topic2);

                db.SaveChanges();

                var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
                var user2Creds = new UserCredential { Login = "Bobj", Password = "asdfgh585" };
                var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
                //  var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };

                // Связать объекты сущноностей User и UserCredential 
                user1Creds.User = user1;
                user2Creds.UserId = user2.Id;
                user3.UserCredential = user3Creds;
                // user4.UserCredential = user4Creds;

                db.UserCredentials.AddRange(user1Creds, user2Creds, user3Creds);

                db.SaveChanges();










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

        static void UserLinq()
        {
            // Создаем контекст для добавления данных
            using (var db = new AppContext())
            {
                // Пересоздаем базу
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Заполняем данными
                var company1 = new Company { Name = "SF" };
                var company2 = new Company { Name = "VK" };
                var company3 = new Company { Name = "FB" };
                db.Companies.AddRange(company1, company2, company3);

                var user1 = new User { Name = "Arthur", Role = "Admin", Company = company1 };
                var user2 = new User { Name = "Bob", Role = "Admin", Company = company2 };
                var user3 = new User { Name = "Clark", Role = "User", Company = company2 };
                var user4 = new User { Name = "Dan", Role = "User", Company = company3 };

                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();
            }

            // Создаем контекст для выбора данных
            using (var db = new AppContext())
            {
                var usersQuery =
                    from user in db.Users
                    where user.CompanyId == 2
                    select user;

                var users = db.Users.Where(user => user.CompanyId == 2);

                var userCompany = db.Users.Select(v => v.Company);

                var firstUser = db.Users.First();

                var joinedCompanies = db.Users.Join(db.Companies, c => c.CompanyId, p => p.Id,
                    (p, c) => new { CompanyName = p.Name });

                var sumCompanies = db.Users.Sum(v => v.CompanyId);
            }
        }
    }
}
