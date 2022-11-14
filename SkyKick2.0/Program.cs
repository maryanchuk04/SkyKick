using Microsoft.Extensions.DependencyInjection;
using SkyKick2._0.Command;
using SkyKick2._0.Directions;
using SkyKick2._0.Interfaces;

namespace SkyKick2._0;

static class Program
{
    private static IServiceProvider _serviceProvider;

    static Program()
    {
        ConfigureServices();
    }
    
    
    public static void Main(string[] args)
    {
        //Get service
        var dataReader = _serviceProvider.GetRequiredService<IReader>();
        var roverService = _serviceProvider.GetRequiredService<IRoverService>();
        var writer = _serviceProvider.GetRequiredService<IWriter>();
        
        var plateau = dataReader.ReadPlateau();
        var rover = dataReader.ReadRover(plateau);
        roverService.ExecuteCommands(rover, dataReader.GetCommandsList(dataReader.ReadCommandString()));
        writer.Write(rover);
    }

    private static void ConfigureServices()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<ICommandParser, CommandParser>()
            .AddSingleton<IReader, ConsoleReader>()
            .AddSingleton<IDirectionsParser, DirectionsParser>()
            .AddSingleton<IRoverService, RoverService>()
            .AddSingleton<IWriter, ConsoleWriter>()
            .BuildServiceProvider();
    }
}