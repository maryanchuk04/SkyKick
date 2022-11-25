using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Readers;

public class PlateauReader : IReader<Plateau>
{
    public Plateau Read()
    {
        Console.Write("Enter Graph Upper Right Coordinate: ");
        var boundString = Console.ReadLine();
        if (boundString == null)
        {
            throw new IncorrectInputDataException("String must be not empty!");
        }
        
        var arrayBound = boundString.Trim().Split(" ").Select(int.Parse).ToList();
        if (arrayBound.Count != 2)
            throw new IncorrectInputDataException("You input bad coordinate of bounds");
        return new Plateau(arrayBound[0], arrayBound[1]);
    }
}