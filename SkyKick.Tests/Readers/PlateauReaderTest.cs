using Moq;
using NUnit.Framework;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Readers;

namespace SkyKick.Tests.Readers;

[TestFixture]
public class PlateauReaderTest
{
    private static IReader<Plateau> plateauReader;
    
    [SetUp]
    public void SetUp()
    {
        plateauReader = new PlateauBuilder();
    }

    [Test]
    public void ReadThrows_ClearString()
    {
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            Console.SetIn(new StringReader(""));
            plateauReader.Read();
        });
    }
    
    [Test]
    public void ReadThrows_NotCorrectInputData()
    {
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            Console.SetIn(new StringReader("1 1 1"));
            plateauReader.Read();
        });
    }

    [Test] 
    public void ReadReturn_Plateau()
    {
        Console.SetIn(new StringReader("5 5"));
        var plateau = plateauReader.Read();
        Assert.Multiple(() =>
        {
            Assert.That(plateau.UpperBoundX, Is.EqualTo(5));
            Assert.That(plateau.UpperBoundY, Is.EqualTo(5));
        });
    }
}