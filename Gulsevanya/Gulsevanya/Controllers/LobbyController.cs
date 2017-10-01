using Gulsevanya.Hubs;
using Gulsevanya.Models;
using Gulsevanya.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;

namespace Gulsevanya.Controllers
{
    [Route("api/[controller]")]
    public class LobbyController : Controller
    {
        private IHubContext<LobbyHub> _lobbyHubContext;
        private ILobbyRepository _lobbyRepository;
        private IUserRepository _userRepository;

        public LobbyController(ILobbyRepository lobbyRepository, IUserRepository userRepository, IHubContext<LobbyHub> hubContext)
        {
            _lobbyHubContext = hubContext;
            _lobbyRepository = lobbyRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<Lobby> GetLobbies()
        {
            return _lobbyRepository.GetAll();
        }

        [HttpGet]
        [Route("{lobbyId}")]
        public void JoinLobby(int lobbyId)
        {
            var user = _userRepository.GetUser(1);

            _lobbyRepository.AddUserToLobby(lobbyId, user);
            var LobbyMessage = new LobbyMessage
            {
                Message = $"User {user.Name} has joined",
                Sent = DateTime.Now,
            };
            _lobbyHubContext.Clients.All.InvokeAsync("UserJoined", LobbyMessage);
        }

        [HttpPost]
        public Lobby CreateLobby([FromBody]Lobby lobby)
        {
            var newLobby = new Lobby
            {
                Name = lobby.Name,
            };
            return _lobbyRepository.CreateLobby(newLobby);
        }

    }
}
