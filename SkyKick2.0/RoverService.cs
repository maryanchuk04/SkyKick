using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0;

public class RoverService : IRoverService
{
    public void ExecuteCommands(Rover rover, List<ICommand> commands)
    {
        commands.ForEach(command=>command.Execute(rover));
    }
}