using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Services;

namespace Magnus.Futbot.Database
{
    public class AddProfilesWorker
    {
        private readonly AddProfileConsumer _addProfileConsumer;
        private readonly ProfilesService _profilesService;

        public AddProfilesWorker(AddProfileConsumer addProfileConsumer,
            ProfilesService profilesService)
        {
            _addProfileConsumer = addProfileConsumer;
            _profilesService = profilesService;
        }

        public async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                var message = _addProfileConsumer.Consume(stoppingToken);
                if (message != null)
                {
                    await _profilesService.Add(message.Message.Value);
                }
            }
        }
    }
}
