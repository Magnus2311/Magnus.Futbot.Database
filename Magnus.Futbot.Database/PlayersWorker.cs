using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Services;

namespace Magnus.Futbot.Database
{
    public class PlayersWorker : BackgroundService
    {
        private readonly PlayerConsumer _playerConsumer;
        private readonly PlayersService _playersService;

        public PlayersWorker(PlayerConsumer playerConsumer,
            PlayersService playersService)
        {
            _playerConsumer = playerConsumer;
            _playersService = playersService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _playerConsumer.Subscribe();
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = _playerConsumer.Consume(stoppingToken);
                if (message != null)
                    await _playersService.Add(message.Message.Value);
            }
        }
    }
}