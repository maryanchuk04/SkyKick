using SkyKick.Domain.Enum;

namespace SkyKick.Domain.Interfaces;

public interface IDirectionsParser
{
    Direction Parse(char direction);
}