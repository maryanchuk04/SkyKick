using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Services.Directions;

public class DirectionsParser : IDirectionsParser
{
    private readonly IDictionary<char, IDirection> _directions;

    public DirectionsParser()
    {
        _directions = new Dictionary<char, IDirection>
        {
            {'E', new EastDirection()},
            {'N', new NorthDirection()},
            {'S', new SouthDirection()},
            {'W', new WestDirection()}
        };
    }

    public IDirection Parse(char direction)
    {
        return _directions[direction];
    }

    public string UnParse(IDirection direction)
    {
        foreach (var key in _directions.Keys)
        {
            if (_directions[key].GetType() == direction.GetType())
                return key.ToString();
        }
        throw new UnParseException("Direction must be not null!");
    }
}