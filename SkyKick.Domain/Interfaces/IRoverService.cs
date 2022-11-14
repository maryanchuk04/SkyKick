using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IRoverService
{
    void ExecuteCommands(Rover rover, List<ICommand> commands);
}