using Confluent.Kafka;
using Magnus.Futbot.Common.Models.Kafka;

namespace Magnus.Futbot.Database.Consumers.Requests
{
    public class ProfilesRequestsConsumer : BaseConsumer<Ignore, string>
    {
        public ProfilesRequestsConsumer(IConfiguration configuration) : base(configuration)
        {
        }

        public override string Topic => "Magnus.Futbot.Profiles.Requests";

        public override string GroupId => "Magnus.Futbot.Database.Profiles.Requests.Consumer";
    }
}
