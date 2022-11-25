using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Services.Readers;

public class CommandsReader : IReader<List<ICommand>>
{
    private readonly ICommandParser _commandParser;
    
    public CommandsReader(ICommandParser commandParser)
    {
        _commandParser = commandParser;
    }
    
    public List<ICommand> Read()
    {
        Console.Write("Rover Movement Plan: ");
        var commandString = Console.ReadLine();
        if (commandString == null)
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }

        return _commandParser.Parse(commandString.Trim());
    }
}