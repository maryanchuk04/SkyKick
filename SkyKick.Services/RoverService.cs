using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services;

public class RoverService : IRoverService
{
    public Plateau? Plateau { get; set; }
    public Rover? Rover { get; set; }
    
    public void ExecuteCommands(List<ICommand> commands)
    {
        if (Rover == null || Plateau == null)
            throw new NullReferenceException("Plateau or Rover is Null");
        commands.ForEach(command =>
        {
            command.Execute(Rover);
            Validate();
        });
    }

    private void Validate()
    {
        if (Rover!.X > Plateau!.UpperBoundX
            ||Rover.Y > Plateau.UpperBoundY
            || Rover.X < Plateau.LowerBoundX
            || Rover.Y < Plateau.LowerBoundY)
            throw new RoverCoordinatesOutBoundsException("Coordinates of rover out the bounds plateau!");
    }
}