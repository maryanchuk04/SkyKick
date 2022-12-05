using Microsoft.Extensions.DependencyInjection;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services;
using SkyKick.Services.Builders;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;
using SkyKick.Services.Interfaces;
using SkyKick.Services.Interfaces.Providers;
using SkyKick.Services.Validators;

namespace SkyKick;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton<IParser<List<ICommand>, List<char>>, CommandParser>()
            .AddSingleton<IBuilder<IRover>, RoverBuilder>()
            .AddSingleton<IBuilder<IPlateau>, PlateauBuilder>()
            .AddSingleton<IBuilder<List<ICommand>>, CommandsBuilder>()
            .AddSingleton<IParser<Direction, char>, DirectionsParser>()
            .AddSingleton<IRoverService, RoverService>()
            .AddSingleton<IWriter, ConsoleChannel>()
            .AddSingleton<ICoordinateProvider, ConsoleChannel>()
            .AddSingleton<ICommandsProvider, ConsoleChannel>()
            .AddSingleton<IDirectionProvider, ConsoleChannel>()
            .AddSingleton<ICoordinatesValidator, CoordinatesValidator>()
            .BuildServiceProvider();
    }
}