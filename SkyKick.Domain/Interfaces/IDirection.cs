using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IDirection
{ 
    IDirection RotateLeft();

    IDirection RotateRight();

    void MoveUp(Rover rover);
}