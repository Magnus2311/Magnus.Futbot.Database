using Confluent.Kafka;
using Magnus.Futbot.Common.Models.DTOs;
using Magnus.Futbot.Common.Models.Kafka;

namespace Magnus.Futbot.Database.Consumers
{
    public class PlayerConsumer : BaseConsumer<Ignore, PlayerDTO>
    {
        public PlayerConsumer(IConfiguration configuration) : base(configuration)
        {
        }

        public override string Topic => "EA.Players.All";

        public override string GroupId => "Magnus.Database.Players.Consumer";
    }
}
