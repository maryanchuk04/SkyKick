using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Services;

public class RoverService : IRoverService
{
    private readonly IWriter _writer;

    public RoverService(IWriter writer)
    {
        _writer = writer;
    }

    public IPlateau? Plateau { get; set; }
    public IRover? Rover { get; set; }
    
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

    public void OutputResults()
    {
        _writer.Write(Rover!);
    }

    private void Validate()
    {
        if (Rover!.CurrentPosition.X > Plateau!.UpperBoundX
            ||Rover.CurrentPosition.Y > Plateau.UpperBoundY
            || Rover.CurrentPosition.X < Plateau.LowerBoundX
            || Rover.CurrentPosition.Y < Plateau.LowerBoundY)
            throw new RoverCoordinatesOutBoundsException("Coordinates of rover out the bounds plateau!");
    }
}