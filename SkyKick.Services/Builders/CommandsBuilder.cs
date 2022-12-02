using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Parsers;
using SkyKick.Domain.Interfaces.Providers;

namespace SkyKick.Services.Builders;

public class CommandsBuilder : IBuilder<List<ICommand>>
{
    private readonly ICommandsProvider _commandsProvider;
    private readonly IParser<List<ICommand>, List<char>> _commandParser;
    
    public CommandsBuilder(ICommandsProvider commandsProvider, IParser<List<ICommand>, List<char>> commandParser)
    {
        _commandsProvider = commandsProvider;
        _commandParser = commandParser;
    }

    public List<ICommand> Build()
    {
        var res = _commandParser.Parse(_commandsProvider.Provide());
        return res;
    } 
}