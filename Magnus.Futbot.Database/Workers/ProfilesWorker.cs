using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Services;

namespace Magnus.Futbot.Database.Workers
{
    public class ProfilesWorker : BackgroundService
    {
        private readonly ProfilesService _profilesService;
        private readonly ProfilesConsumer _profilesConsumer;

        public ProfilesWorker(ProfilesService profilesService,
            ProfilesConsumer profilesConsumer)
        {
            _profilesService = profilesService;
            _profilesConsumer = profilesConsumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
            => Task.Run(async () =>
            {
                while(!stoppingToken.IsCancellationRequested)
                {
                    var profileMessage = _profilesConsumer.Consume();
                    if (profileMessage is not null)
                    {
                        await _profilesService.Update(profileMessage.Message.Value);
                    }
                }
            }, stoppingToken);
    }
}
