using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services;

public class RoverService : IRoverService
{
    public void ExecuteCommands(Rover rover, List<ICommand> commands)
    {
        commands.ForEach(command=>command.Execute(rover));
    }
}