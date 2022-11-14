namespace SkyKick.Domain.Interfaces;

public interface ICommandParser
{
    List<ICommand> Parse(string commandString);
}