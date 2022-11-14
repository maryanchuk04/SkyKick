using SkyKick2._0.Interfaces;

namespace SkyKick2._0.Command;

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
    
    public List<ICommand> Parse(string commandString)
    {
        return commandString.Select(command => _commands[command]).ToList();
    }

}