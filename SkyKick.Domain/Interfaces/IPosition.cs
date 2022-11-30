using SkyKick.Domain.Enum;

namespace SkyKick.Domain.Interfaces;

public interface IPosition
{ 
    int X { get; set; }
    int Y { get; set; }
    Direction Direction { get; set; }
}