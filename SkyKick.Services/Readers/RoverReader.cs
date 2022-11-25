using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Readers;

public class RoverReader : IReader<Rover>
{
    private readonly IDirectionsParser _directionsParser;
    
    public RoverReader(IDirectionsParser directionsParser)
    {
        _directionsParser = directionsParser;
    }
    
    public Rover Read()
    {
        Console.Write("Rover Starting Position: ");
        var inputRoverString = Console.ReadLine();
        if (inputRoverString == null)
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }
        
        var arrayStrDateOfRover = inputRoverString.Trim().Split(" ").ToList();
        
        if (arrayStrDateOfRover.Count != 3)
            throw new IncorrectInputDataException("You input bad coordinate");
        
        var x = int.Parse(arrayStrDateOfRover[0]);
        var y = int.Parse(arrayStrDateOfRover[1]);
        var direction = _directionsParser.Parse(char.Parse(arrayStrDateOfRover[2]));
        return new Rover(x, y, direction);
    }
}