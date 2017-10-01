using Gulsevanya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gulsevanya.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(int id)
        {
            return new User { Name = "John" };
        }
    }
}
