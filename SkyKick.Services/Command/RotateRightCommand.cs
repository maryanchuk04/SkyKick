using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Command;

public class RotateRightCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.Direction = rover.Direction.RotateRight();
    }
}