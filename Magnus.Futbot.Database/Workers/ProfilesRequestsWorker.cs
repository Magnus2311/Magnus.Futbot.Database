using Magnus.Futbot.Database.Consumers.Requests;
using Magnus.Futbot.Database.Kafka.Producers;
using Magnus.Futbot.Database.Services;

namespace Magnus.Futbot.Database.Workers
{
    public class ProfilesRequestsWorker : BackgroundService
    {
        private readonly ProfilesService _profilesService;
        private readonly ProfilesProducer _profilesProducer;
        private readonly ProfilesRequestsConsumer _profilesRequestsConsumer;

        public ProfilesRequestsWorker(ProfilesService profilesService,
            ProfilesRequestsConsumer profilesRequestsConsumer,
            ProfilesProducer profilesProducer)
        {
            _profilesService = profilesService;
            _profilesProducer = profilesProducer;
            _profilesRequestsConsumer = profilesRequestsConsumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
            => Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var message = _profilesRequestsConsumer.Consume();
                    if (message is not null)
                    {
                        var profiles = await _profilesService.GetAllByUserId(message.Message.Value);
                        foreach (var profile in profiles)
                            await _profilesProducer.Produce(message.Message.Value, profile, stoppingToken);
                    }
                }
            }, stoppingToken);
    }
}
