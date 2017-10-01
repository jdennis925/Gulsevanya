using Gulsevanya.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Gulsevanya.Repositories
{
    public class LobbyRepository : ILobbyRepository
    {
        readonly Dictionary<int, Lobby> _openLobbies = new Dictionary<int, Lobby>();
        private int maxLobbyId;

        public IEnumerable<Lobby> GetAll()
        {
            return _openLobbies.Select(o => o.Value);
        }

        public void AddUserToLobby(int lobbyId, User user)
        {
            if(_openLobbies.ContainsKey(lobbyId))
            {
                _openLobbies[lobbyId].Users.Add(user);
            }
        }

        public Lobby CreateLobby(Lobby lobby)
        {
            int newId = Interlocked.Increment(ref maxLobbyId);
            lobby.Id = newId;
            _openLobbies.Add(newId, lobby);
            return lobby;
        }
    }
}
