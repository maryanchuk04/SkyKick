using Microsoft.Extensions.DependencyInjection;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Services.Interfaces;

namespace SkyKick;

static class Program
{
    private static IServiceProvider _serviceProvider;
    private static readonly IBuilder<IRover> RoverBuilder;
    private static readonly IBuilder<IPlateau> PlateauBuilder;
    private static readonly IBuilder<List<ICommand>> CommandsBuilder;
    private static readonly IRoverService _roverService;
    
    static Program()
    {
        _serviceProvider = Startup.ConfigureServices();
        if (_serviceProvider == null)
            throw new ConfigureServicesException("Service provider not configured!");
        RoverBuilder = _serviceProvider.GetRequiredService<IBuilder<IRover>>();
        PlateauBuilder = _serviceProvider.GetRequiredService<IBuilder<IPlateau>>();
        CommandsBuilder = _serviceProvider.GetRequiredService<IBuilder<List<ICommand>>>();
        _roverService = _serviceProvider.GetRequiredService<IRoverService>();
    }
    
    public static void Main()
    {
        try
        {
            Console.Write("Plateau ");
            var plateau = PlateauBuilder.Build();
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
        var rover = RoverBuilder.Build();
        _roverService.Rover = rover;
        _roverService.Plateau = plateau;
        _roverService.ExecuteCommands(CommandsBuilder.Build());
        _roverService.OutputResults();
    }
}