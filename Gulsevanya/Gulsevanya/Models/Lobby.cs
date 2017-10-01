using System.Collections.Generic;

namespace Gulsevanya.Models
{
    public class Lobby
    {
        public Lobby()
        {
            Users = new List<User>();
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public IList<User> Users{get; set;}
    }
}
