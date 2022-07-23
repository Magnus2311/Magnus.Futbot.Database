using AutoMapper;
using Magnus.Futbot.Database;
using Magnus.Futbot.Database.Consumers;
using Magnus.Futbot.Database.Helpers;
using Magnus.Futbot.Database.Repositories;
using Magnus.Futbot.Database.Services;


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton(mapper);

        services.AddSingleton<PlayerConsumer>();

        services
            .AddTransient<PlayersRepository>()
            .AddTransient<ProfilesRepository>();

        services
            .AddTransient<PlayersService>();

        services.AddHostedService<PlayersWorker>();
    });

var host = hostBuilder.Build();

await host.RunAsync();
