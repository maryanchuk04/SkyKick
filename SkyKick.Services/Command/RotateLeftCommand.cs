using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Extensions;

namespace SkyKick.Services.Command;

public class RotateLeftCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.Direction = rover.Direction.Previous();
    }
}