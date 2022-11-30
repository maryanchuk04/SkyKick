using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Readers;

namespace SkyKick.Tests.Readers;

[TestFixture]
public class RoverReaderTest
{
    private static IReader<Rover> roverReader;
    
    [SetUp]
    public void SetUp()
    {
        var mockDirectionParser = new Mock<IDirectionsParser>();
        roverReader = new RoverBuilder(mockDirectionParser.Object);
    }

    [Test]
    public void ReadThrowsIncorrectIde_ClearInputString()
    {
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            Console.SetIn(new StringReader(""));
            roverReader.Read();
        });
    }
    
    [Test]
    public void ReadThrowsIncorrectIde_InputStringIsNotCorrect()
    {
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            Console.SetIn(new StringReader("1 2 N N"));
            roverReader.Read();
        });
    }
    
    [Test]
    public void ReadRover()
    {
        Console.SetIn(new StringReader("1 2 N "));
        var rover = roverReader.Read();
        Assert.Multiple(() =>
        {
            Assert.That(rover.X, Is.EqualTo(1));
            Assert.That(rover.Y, Is.EqualTo(2));
            Assert.That(rover.Direction, Is.EqualTo(Direction.N));
        });
    }
    
}