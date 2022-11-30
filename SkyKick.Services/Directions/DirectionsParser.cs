using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Services.Directions;

public class DirectionsParser : IDirectionsParser
{
    public Direction Parse(char direction)
    {
        return (Direction)Enum.Parse(typeof(Direction), direction.ToString());
    }
}