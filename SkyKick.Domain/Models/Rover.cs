using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Domain.Models;

public class Rover : IRover
{
    public Rover(IPosition startPosition)
    {
        CurrentPosition = startPosition;
    }

    public IPosition CurrentPosition { get; }
}