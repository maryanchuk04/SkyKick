using SkyKick.Domain.Enum;

namespace SkyKick.Domain.Interfaces.Parsers;

public interface IDirectionsParser
{
    Direction Parse(char direction);
}