using AutoMapper;
using Magnus.Futbot.Common.Models.DTOs;
using Magnus.Futbot.Database.Models;
using Magnus.Futbot.Database.Repositories;

namespace Magnus.Futbot.Database.Services
{
    public class PlayersService
    {
        private readonly PlayersRepository _playersRepository;
        private readonly IMapper _mapper;

        public PlayersService(PlayersRepository playersRepository,
            IMapper mapper)
        {
            _playersRepository = playersRepository;
            _mapper = mapper;
        }

        public async Task Add(PlayerDTO player)
        {
            var allPlayers = await _playersRepository.GetAll();
            if (allPlayers.Any(p => p.Id == player.Id)) return;

            await _playersRepository.Add(_mapper.Map<PlayerDocument>(player));
        }
    }
}
