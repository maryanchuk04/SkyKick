using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IReader
{
    Plateau ReadPlateau();
    Rover ReadRover(Plateau plateau);
    List<ICommand> GetCommandsList(string commandString);
    string ReadCommandString();
}