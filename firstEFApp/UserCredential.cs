using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstEFApp
{
    public class UserCredential
    {   
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Внешний ключ
        public int UserId { get; set; }
        
        // Навигационное свойство
        public User User { get; set; }
    }
}
