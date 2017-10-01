using Gulsevanya.Models;

namespace Gulsevanya.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
    }
}