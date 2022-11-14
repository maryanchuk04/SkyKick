using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Readers;

public class ConsoleReader : IReader
{
    private readonly ICommandParser _commandParser;
    private readonly IDirectionsParser _directionsParser;
    
    public ConsoleReader(ICommandParser commandParser, IDirectionsParser directionsParser)
    {
        _commandParser = commandParser;
        _directionsParser = directionsParser;
    }
    
    public Plateau ReadPlateau()
    {
        Console.Write("Enter Graph Upper Right Coordinate: ");
        var boundString = Console.ReadLine();
        if (boundString == null)
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }
        
        var arrayBound = boundString.Trim().Split(" ").Select(int.Parse).ToList();
        if (arrayBound.Count != 2)
            throw new IncorrectInputDataException("You input bad coordinate of bounds");
        return new Plateau(arrayBound[0], arrayBound[1]);
    }

    public Rover ReadRover(Plateau plateau)
    {
        Console.Write("Rover Starting Position: ");
        var inputRoverString = Console.ReadLine();
        if (inputRoverString == null)
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }
        
        var arrayStrDateOfRover = inputRoverString.Trim().Split(" ").ToList();
        
        if (arrayStrDateOfRover.Count != 3)
            throw new IncorrectInputDataException("You input bad coordinate");
        
        var x = int.Parse(arrayStrDateOfRover[0]);
        var y = int.Parse(arrayStrDateOfRover[1]);
        var direction = _directionsParser.Parse(char.Parse(arrayStrDateOfRover[2]));
        return new Rover(plateau, x, y, direction);
    }

    public List<ICommand> GetCommandsList(string commandString) => _commandParser.Parse(commandString);
    
    public string ReadCommandString()
    {
        Console.Write("Rover Movement Plan: ");
        var commandString = Console.ReadLine();
        if (commandString == null)
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }
        
        return commandString.Trim();
    }
}