using SkyKick2._0.Models;

namespace SkyKick2._0.Interfaces;

public interface IDirection
{ 
    IDirection RotateLeft();

    IDirection RotateRight();

    void MoveUp(Rover rover);
}