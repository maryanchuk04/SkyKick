using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Providers;

namespace SkyKick.Services.Readers;

public class CommandsBuilder : IReader<List<ICommand>>
{
    private readonly ICommandsProvider _commandsProvider;
    
    public CommandsBuilder(ICommandsProvider commandsProvider)
    {
        _commandsProvider = commandsProvider;
    }
    
    public List<ICommand> Read()
    {
        return _commandsProvider.Provide();
    }
}