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
    private static readonly IReader _reader;
    private static readonly IWriter _writer;
    private static readonly IRoverService _roverService;
    
    static Program()
    {
        ConfigureServices();
        if (_serviceProvider == null)
            throw new ConfigureServicesException("Service provider not configured!");
        _reader = _serviceProvider.GetRequiredService<IReader>();
        _roverService = _serviceProvider.GetRequiredService<IRoverService>();
        _writer = _serviceProvider.GetRequiredService<IWriter>();
    }
    
    
    public static void Main(string[] args)
    {
        var plateau = _reader.ReadPlateau();
        for (int i = 0; i < 2; i++)
        {
            Input(plateau);
        }
    }

    private static void Input(Plateau plateau)
    {
        var rover = _reader.ReadRover(plateau);
        _roverService.ExecuteCommands(rover, _reader.ReadCommands());
        _writer.Write(rover);
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