using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Writers;

public class ConsoleWriter : IWriter
{
    private readonly IDirectionsParser _directionsParser;
    
    public ConsoleWriter(IDirectionsParser directionsParser)
    {
        _directionsParser = directionsParser;
    }
    
    public void Write(Rover rover)
    {
        Console.WriteLine($"Rover Output: {rover.X} {rover.Y} {_directionsParser.UnParse(rover.Direction)}");
    }
}