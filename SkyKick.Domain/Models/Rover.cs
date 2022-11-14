using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Domain.Models;

public class Rover
{
    private readonly Plateau _plateau;
    private int _coordinateX;
    private int _coordinateY;
    public IDirection Direction;

    public Rover(Plateau plateau, int coordinateX, int coordinateY, IDirection direction)
    {
        _plateau = plateau ?? throw new PlateauNullException("Plateau must be not null");
        _coordinateX = coordinateX;
        _coordinateY = coordinateY;
        Direction = direction;
        ValidateLocation();
    }
    
    public void ValidateLocation() {
        if (_coordinateX > _plateau.UpperBoundX
            ||_coordinateY > _plateau.UpperBoundY
            || _coordinateX < Plateau.LowerBoundX
            || _coordinateY < Plateau.LowerBoundY)
            throw new RoverCoordinatesOutBoundsException("Coordinates out the bounds plateau!");
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