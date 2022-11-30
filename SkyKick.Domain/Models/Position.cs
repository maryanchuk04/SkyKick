using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Domain.Models;

public class Position : IPosition
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Direction { get; set; }

    public Position(int x, int y, Direction direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }
}