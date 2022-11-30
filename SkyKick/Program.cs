using Microsoft.Extensions.DependencyInjection;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick;

static class Program
{
    private static IServiceProvider _serviceProvider;
    private static readonly IReader<IRover> _roverReader;
    private static readonly IReader<IPlateau> _plateauReader;
    private static readonly IReader<List<ICommand>> _commandsReader;
    private static readonly IRoverService _roverService;
    
    static Program()
    {
        _serviceProvider = Startup.ConfigureServices();
        if (_serviceProvider == null)
            throw new ConfigureServicesException("Service provider not configured!");
        _roverReader = _serviceProvider.GetRequiredService<IReader<IRover>>();
        _plateauReader = _serviceProvider.GetRequiredService<IReader<IPlateau>>();
        _commandsReader = _serviceProvider.GetRequiredService<IReader<List<ICommand>>>();
        _roverService = _serviceProvider.GetRequiredService<IRoverService>();
    }
    
    public static void Main()
    {
        try
        {
            Console.Write("Plateau ");
            var plateau = _plateauReader.Read();
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Rover ");
                Input(plateau);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void Input(IPlateau plateau)
    {
        var rover = _roverReader.Read();
        _roverService.Rover = rover;
        _roverService.Plateau = plateau;
        _roverService.ExecuteCommands(_commandsReader.Read());
        _roverService.OutputResults();
    }
}