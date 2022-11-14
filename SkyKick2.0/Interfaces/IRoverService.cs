using SkyKick2._0.Models;

namespace SkyKick2._0.Interfaces;

public interface IRoverService
{
    void ExecuteCommands(Rover rover, List<ICommand> commands);
}