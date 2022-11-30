using SkyKick.Domain.Interfaces;
using SkyKick.Services.Extensions;

namespace SkyKick.Services.Command;

public class RotateLeftCommand : ICommand
{
    public void Execute(IRover rover)
    {
        rover.CurrentPosition.Direction = rover.CurrentPosition.Direction.Previous();
    }
}