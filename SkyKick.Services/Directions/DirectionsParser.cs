using SkyKick.Domain.Enum;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Services.Directions;

public class DirectionsParser : IDirectionsParser
{
    private readonly IDictionary<char, Direction> _directions;

    public DirectionsParser()
    {
        _directions = new Dictionary<char, Direction>
        {
            {'E', Direction.E},
            {'N', Direction.N},
            {'S', Direction.S},
            {'W', Direction.W}
        };
    }

    public Direction Parse(char direction)
    {
        return _directions[direction];
    }
}