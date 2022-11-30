using SkyKick.Domain.Enum;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Providers;

namespace SkyKick.Services;

public class ConsoleChannel : ICommandsProvider, IDirectionProvider, ICoordinateProvider, IWriter
{
    private readonly IDirectionsParser _directionsParser;
    private readonly ICommandParser _commandParser;
    private const string Separator = " ";

    public ConsoleChannel(IDirectionsParser directionsParser, ICommandParser commandParser)
    {
        _directionsParser = directionsParser;
        _commandParser = commandParser;
    }

    List<ICommand> ICommandsProvider.Provide()
    {
        Console.Write("Rover Movement Plan: ");
        var commandString = Console.ReadLine();
        if (string.IsNullOrEmpty(commandString))
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }

        return _commandParser.Parse(commandString.Trim());
    }

    Direction IDirectionProvider.Provide()
    {
        Console.Write("Rover Starting Direction: ");
        var inputDirectionString = Console.ReadLine();
        if (string.IsNullOrEmpty(inputDirectionString) || inputDirectionString.Length != 1) 
        {
            throw new IncorrectInputDataException("Direction is not correct");
        }

        return _directionsParser.Parse(char.Parse(inputDirectionString));
    }

    (int, int) ICoordinateProvider.Provide()
    {
        Console.Write("Starting Coordinates: ");
        var inputCoordinatesString = Console.ReadLine();
        if (string.IsNullOrEmpty(inputCoordinatesString))
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }
        
        var arrayStrDateOfRover = inputCoordinatesString.Trim().Split(Separator).ToList();
        if (arrayStrDateOfRover.Count != 2)
            throw new IncorrectInputDataException("You input bad coordinate");
        
        if (!int.TryParse(arrayStrDateOfRover[0], out var x))
        {
            throw new IncorrectInputDataException("Coordinates must be number");
        }
        
        if (!int.TryParse(arrayStrDateOfRover[1], out var y))
        {
            throw new IncorrectInputDataException("Coordinates must be number");
        }
        
        return (x, y);
    }

    public void Write(IRover rover)
    {
        Console.WriteLine($"Rover Output: {rover.CurrentPosition.X} {rover.CurrentPosition.Y} {rover.CurrentPosition.Direction}");
    }
}