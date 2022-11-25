using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IReader
{
    Plateau ReadPlateau();
    Rover ReadRover();
    List<ICommand> ReadCommands();
}