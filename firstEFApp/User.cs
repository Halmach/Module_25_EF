using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstEFApp
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }


        // Навигационное свойство
        public UserCredential UserCredential { get; set; }
        // Внешний ключ
        public int CompanyId { get; set; }

        // Навигационное свойство
        public Company Company { get; set; }

        // Навигационное свойство
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
