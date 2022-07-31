using AutoMapper;
using Magnus.Futbot.Database;
using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Consumers.Requests;
using Magnus.Futbot.Database.Helpers;
using Magnus.Futbot.Database.Kafka.Producers;
using Magnus.Futbot.Database.Repositories;
using Magnus.Futbot.Database.Services;
using Magnus.Futbot.Database.Workers;

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton(mapper);

        services
            .AddSingleton<PlayerConsumer>()
            .AddSingleton<AddProfileConsumer>()
            .AddSingleton<ProfilesConsumer>()
            .AddSingleton<ProfilesRequestsConsumer>();

        services
            .AddTransient<ProfilesProducer>();

        services
            .AddTransient<PlayersRepository>()
            .AddTransient<ProfilesRepository>();

        services
            .AddTransient<PlayersService>()
            .AddTransient<ProfilesService>();

        services
            .AddSingleton<AddProfilesWorker>()
            .AddSingleton<PlayersWorker>();

        services
            .AddHostedService<PlayersWorker>()
            .AddHostedService<AddProfilesWorker>()
            .AddHostedService<ProfilesWorker>()
            .AddHostedService<ProfilesRequestsWorker>();
    });

var host = hostBuilder.Build();

await host.RunAsync();
