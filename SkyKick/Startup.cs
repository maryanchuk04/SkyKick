using Microsoft.Extensions.DependencyInjection;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Providers;
using SkyKick.Domain.Models;
using SkyKick.Services;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;
using SkyKick.Services.Readers;

namespace SkyKick;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton<ICommandParser, CommandParser>()
            .AddSingleton<IReader<IRover>, RoverBuilder>()
            .AddSingleton<IReader<IPlateau>, PlateauBuilder>()
            .AddSingleton<IReader<List<ICommand>>, CommandsBuilder>()
            .AddSingleton<IDirectionsParser, DirectionsParser>()
            .AddSingleton<IRoverService, RoverService>()
            .AddSingleton<IWriter, ConsoleChannel>()
            .AddSingleton<ICoordinateProvider, ConsoleChannel>()
            .AddSingleton<ICommandsProvider, ConsoleChannel>()
            .AddSingleton<IDirectionProvider, ConsoleChannel>()
            .BuildServiceProvider();
    }
}