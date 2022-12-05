using SkyKick.Domain.Enum;
using SkyKick.Services.Interfaces;

namespace SkyKick.Services.Directions;

public class DirectionsParser : IParser<Direction, char>
{
    public Direction Parse(char direction)
    {
        return (Direction)Enum.Parse(typeof(Direction), direction.ToString());
    }
}