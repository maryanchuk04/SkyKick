using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0;

public interface IReader
{
    Plateau ReadPlateau();
    Rover ReadRover(Plateau plateau);
    List<ICommand> GetCommandsList(string commandString);
    string ReadCommandString();
}