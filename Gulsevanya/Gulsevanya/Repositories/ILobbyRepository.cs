using System.Collections.Generic;
using Gulsevanya.Models;

namespace Gulsevanya.Repositories
{
    public interface ILobbyRepository
    {
        Lobby CreateLobby(Lobby lobby);
        IEnumerable<Lobby> GetAll();
        void AddUserToLobby(int lobbyId, User user);
    }
}