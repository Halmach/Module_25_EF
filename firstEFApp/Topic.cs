using System.Collections.Generic;

namespace firstEFApp
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}