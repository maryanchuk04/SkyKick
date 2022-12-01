namespace SkyKick.Domain.Interfaces.Parsers;

public interface ICommandParser
{
    List<ICommand> Parse(List<char> commandString);
}