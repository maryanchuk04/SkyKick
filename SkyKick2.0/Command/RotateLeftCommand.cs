using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0.Command;

public class RotateLeftCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.Direction = rover.Direction.RotateLeft();
    }
}