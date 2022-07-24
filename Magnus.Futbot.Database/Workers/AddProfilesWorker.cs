using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Services;

namespace Magnus.Futbot.Database
{
    public class AddProfilesWorker : BackgroundService
    {
        private readonly AddProfileConsumer _addProfileConsumer;
        private readonly ProfilesService _profilesService;

        public AddProfilesWorker(AddProfileConsumer addProfileConsumer,
            ProfilesService profilesService)
        {
            _addProfileConsumer = addProfileConsumer;
            _profilesService = profilesService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
            => Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var message = _addProfileConsumer.Consume(stoppingToken);
                    if (message != null)
                    {
                        await _profilesService.Add(message.Message.Value);
                    }
                }
            }, stoppingToken);
    }
}