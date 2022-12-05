using SkyKick.Domain.Interfaces;
using SkyKick.Services.Interfaces;

namespace SkyKick.Services.Command;

public class CommandParser : IParser<List<ICommand>, List<char>>
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