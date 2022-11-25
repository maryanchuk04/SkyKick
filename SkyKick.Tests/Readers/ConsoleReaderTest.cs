using Moq;
using NUnit.Framework;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;
using SkyKick.Services.Readers;

namespace SkyKick.Tests.Readers;

[TestFixture]
public class ConsoleReaderTest
{
    private IReader _reader;
    private Plateau _plateau;
    private Mock<ICommandParser> mockCommandParser;
    private Mock<IDirectionsParser> mockDirectionParser;
    private List<ICommand> _commandsTemplate = new List<ICommand>()
    {
        new MoveUpCommand(),
        new MoveUpCommand(),
        new MoveUpCommand(),
        new MoveUpCommand(),
        new RotateLeftCommand(),
        new RotateLeftCommand(),
        new MoveUpCommand()
    };
    
    [SetUp]
    public void SetUp()
    {
        mockCommandParser = new Mock<ICommandParser>();
        mockDirectionParser = new Mock<IDirectionsParser>();
        _reader = new ConsoleReader(mockCommandParser.Object, mockDirectionParser.Object);
        _plateau = new Plateau(5, 5);
        mockCommandParser.Setup(x => x.Parse("MMMMLLM")).Returns(_commandsTemplate);
    }
    
    [Test]
    public void ReadPlateauShouldReturnPlateau()
    {
        Console.SetIn(new StringReader("5 5"));
        Assert.Multiple(() =>
        {
            var res = _reader.ReadPlateau();
            Assert.That(res.UpperBoundX, Is.EqualTo(5));
            Assert.That(res.UpperBoundY, Is.EqualTo(5));
        });
    }

    [Test]
    public void ReadPlateauThrows_IncorrectInputDataException()
    {
        Console.SetIn(new StringReader(""));
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            _reader.ReadPlateau();
        });
    }
    
    [Test]
    public void ReadPlateauBadArrayBound_Throws_IncorrectInputDataException()
    {
        Console.SetIn(new StringReader("5 5 5"));
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            _reader.ReadPlateau();
        });
    }

    [Test]
    public void ReadRoverThrows_IncorrectInputDataException()
    {
        Console.SetIn(new StringReader(""));
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            _reader.ReadRover();
        });
    }

    [Test]
    public void ReadRoverBadArrayBound_Throws_IncorrectInputDataException()
    {
        Console.SetIn(new StringReader("1 4 N S"));
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            _reader.ReadRover();
        });
    }
    
    [Test]
    [TestCase("1 4 N")]
    [TestCase("1 2 E")]
    [TestCase("1 3 W")]
    public void ReadRoverShouldReturnData(string inputStr)
    {
        var arrayStr = inputStr.Split(" ");
        Console.SetIn(new StringReader(inputStr));
        Console.WriteLine(arrayStr[2]);
        Assert.Multiple(() =>
        {
            var res = _reader.ReadRover();
            Assert.That(res.X, Is.EqualTo(int.Parse(arrayStr[0])));
            Assert.That(res.Y, Is.EqualTo(int.Parse(arrayStr[1])));
        });
    }

    [Test]
    public void GetCommandsListThrows_IncorrectInputDataException()
    {
        Console.SetIn(new StringReader(""));
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            _reader.ReadCommands();
        });
    }
    
    [Test]
    public void GetCommandsListReturn()
    {
        Console.SetIn(new StringReader("MMMMLLM"));
        var res = _reader.ReadCommands();
        CollectionAssert.AreEqual(_commandsTemplate.Select(x => x.GetType()), res.Select(x => x.GetType()));
    }
}