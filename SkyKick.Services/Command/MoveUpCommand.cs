

using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Command;

public class MoveUpCommand : ICommand
{
    public void Execute(Rover rover)
    {
       rover.Direction.MoveUp(rover);
       rover.ValidateLocation();
    }
}