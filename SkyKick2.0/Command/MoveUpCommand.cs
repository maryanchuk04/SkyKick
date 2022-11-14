using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0.Command;

public class MoveUpCommand : ICommand
{
    public void Execute(Rover rover)
    {
       rover.Direction.MoveUp(rover);
       rover.ValidateLocation();
    }
}