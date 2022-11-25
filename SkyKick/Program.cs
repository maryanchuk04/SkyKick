using Microsoft.Extensions.DependencyInjection;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;
using SkyKick.Services.Readers;
using SkyKick.Services.Writers;


namespace SkyKick;

static class Program
{
    private static IServiceProvider _serviceProvider;
    private static readonly IReader<Rover> _roverReader;
    private static readonly IReader<Plateau> _plateauReader;
    private static readonly IReader<List<ICommand>> _commandsReader;
    private static readonly IWriter _writer;
    private static readonly IRoverService _roverService;
    
    static Program()
    {
        ConfigureServices();
        if (_serviceProvider == null)
            throw new ConfigureServicesException("Service provider not configured!");
        _roverReader = _serviceProvider.GetRequiredService<IReader<Rover>>();
        _plateauReader = _serviceProvider.GetRequiredService<IReader<Plateau>>();
        _commandsReader = _serviceProvider.GetRequiredService<IReader<List<ICommand>>>();
        _roverService = _serviceProvider.GetRequiredService<IRoverService>();
        _writer = _serviceProvider.GetRequiredService<IWriter>();
    }
    
    public static void Main(string[] args)
    {
        try
        {
            var plateau = _plateauReader.Read();
            for (int i = 0; i < 2; i++)
            {
                Input(plateau);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void Input(Plateau plateau)
    {
        var rover = _roverReader.Read();
        _roverService.Rover = rover;
        _roverService.Plateau = plateau;
        _roverService.ExecuteCommands(_commandsReader.Read());
        _writer.Write(rover);
    }

    private static void ConfigureServices()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<ICommandParser, CommandParser>()
            .AddSingleton<IReader<Rover>, RoverReader>()
            .AddSingleton<IReader<Plateau>, PlateauReader>()
            .AddSingleton<IReader<List<ICommand>>, CommandsReader>()
            .AddSingleton<IDirectionsParser, DirectionsParser>()
            .AddSingleton<IRoverService, RoverService>()
            .AddSingleton<IWriter, ConsoleWriter>()
            .BuildServiceProvider();
    }
}