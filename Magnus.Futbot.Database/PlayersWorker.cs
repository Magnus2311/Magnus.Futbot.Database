using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Services;

namespace Magnus.Futbot.Database
{
    public class PlayersWorker
    {
        private readonly PlayerConsumer _playerConsumer;
        private readonly PlayersService _playersService;

        public PlayersWorker(PlayerConsumer playerConsumer,
            PlayersService playersService)
        {
            _playerConsumer = playerConsumer;
            _playersService = playersService;
        }

        public async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = _playerConsumer.Consume(stoppingToken);
                if (message != null)
                    await _playersService.Add(message.Message.Value);
            }
        }
    }
}