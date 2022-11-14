namespace SkyKick2._0.Interfaces;

public interface ICommandParser
{
    List<ICommand> Parse(string commandString);
}