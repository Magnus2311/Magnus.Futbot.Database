using Confluent.Kafka;
using Magnus.Futbot.Common.Models.Kafka;
using Magnus.Futbot.Common.Models.Selenium.Profiles;

namespace Magnus.Futbot.Database.Consumers
{
    public class AddProfileConsumer : BaseConsumer<Ignore, AddProfileDTO>
    {
        public AddProfileConsumer(IConfiguration configuration) : base(configuration)
        {
        }

        public override string Topic => "Magnus.Futbot.Profiles.Add";

        public override string GroupId => "Magnus.Database.Profiles.Add.Consumer";
    }
}   