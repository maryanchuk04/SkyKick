namespace SkyKick.Domain.Interfaces.Providers;

public interface ICommandsProvider
{
    List<ICommand> Provide();
}