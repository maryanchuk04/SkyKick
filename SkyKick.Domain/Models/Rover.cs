using SkyKick.Domain.Enum;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Domain.Models;

public class Rover
{
    private int _coordinateX;
    private int _coordinateY;
    public Direction Direction;

    public Rover(int coordinateX, int coordinateY, Direction direction)
    {
        _coordinateX = coordinateX;
        _coordinateY = coordinateY;
        Direction = direction;
    }

    public int X
    {
        get => _coordinateX;
        set => _coordinateX = value;
    }
    
    public int Y
    {
        get => _coordinateY;
        set => _coordinateY = value;
    }
}