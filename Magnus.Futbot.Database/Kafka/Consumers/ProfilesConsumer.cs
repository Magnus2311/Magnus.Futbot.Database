using Magnus.Futbot.Common.Models.DTOs;
using Magnus.Futbot.Common.Models.Kafka;

namespace Magnus.Futbot.Database.Consumers
{
    public class ProfilesConsumer : BaseConsumer<string, ProfileDTO>
    {
        public ProfilesConsumer(IConfiguration configuration) : base(configuration)
        {
        }

        public override string Topic => "Magnus.Futbot.Profiles";

        public override string GroupId => "Futbot.Database.Profiles.Consumer";
    }
}
