using Moq;
using NUnit.Framework;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Services.Command;
using SkyKick.Services.Readers;

namespace SkyKick.Tests.Readers;

[TestFixture]
public class CommandsReaderTest
{
    private static IReader<List<ICommand>> _reader;

    [SetUp]
    public void SetUp()
    {
        var mockCommandsParser = new Mock<ICommandParser>();
        mockCommandsParser.Setup(x => x.Parse(("MLML"))).Returns(new List<ICommand>()
        {
            new MoveUpCommand(),
            new RotateLeftCommand(), 
            new MoveUpCommand(),
            new RotateLeftCommand()
        });
        _reader = new CommandsReader(mockCommandsParser.Object);
    }

    [Test]
    public void ReadThrows()
    {
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            Console.SetIn(new StringReader(""));
            _reader.Read();
        });
    }

    [Test]
    public void ReadReturn_CommandsList()
    {
        Console.SetIn(new StringReader("MLML"));
        var res = _reader.Read();
        Assert.That(res, Is.Not.Null);
    }
}