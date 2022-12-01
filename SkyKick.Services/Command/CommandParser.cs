using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Parsers;

namespace SkyKick.Services.Command;

public class CommandParser : ICommandParser
{
    private readonly IDictionary<char, ICommand> _commands;
    
    public CommandParser()
    {
        _commands = new Dictionary<char, ICommand>
        {
            {'M', new MoveUpCommand()},
            {'R', new RotateRightCommand()},
            {'L', new RotateLeftCommand()}
        };
    }
    
    public List<ICommand> Parse(List<char> commandArray)
    {
        return commandArray.Select(command => _commands[command]).ToList();
    }

}