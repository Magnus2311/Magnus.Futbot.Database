using Magnus.Futbot.Common.Models.DTOs;
using Magnus.Futbot.Common.Models.Kafka;

namespace Magnus.Futbot.Database.Kafka.Producers
{
    public class ProfilesProducer : BaseProducer<string, ProfileDTO>
    {
        public ProfilesProducer(IConfiguration configuration) : base(configuration)
        {
            Topic = string.Empty;
        }

        public override string Topic { get; protected set; }

        public override async Task Produce(string key, ProfileDTO value, CancellationToken cancellationToken)
        {
            Topic = $"Magnus.Futbot.Profiles.{key}";
            await base.Produce(key, value, cancellationToken);
        }
    }
}
