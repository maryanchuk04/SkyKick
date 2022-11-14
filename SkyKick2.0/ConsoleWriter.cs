using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0;

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