using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(Rover rover)
    {
        Console.WriteLine($"Rover Output: {rover.X} {rover.Y} {rover.Direction}");
    }
}