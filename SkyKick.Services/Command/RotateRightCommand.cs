using SkyKick.Domain.Interfaces;
using SkyKick.Services.Extensions;

namespace SkyKick.Services.Command;

public class RotateRightCommand : ICommand
{
    public void Execute(IRover rover)
    {
        rover.CurrentPosition.Direction = rover.CurrentPosition.Direction.Next();
    }
}