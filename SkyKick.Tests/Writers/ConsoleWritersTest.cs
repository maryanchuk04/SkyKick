using Moq;
using NUnit.Framework;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Directions;
using SkyKick.Services.Readers;
using SkyKick.Services.Writers;

namespace SkyKick.Tests.Writers;

[TestFixture]
public class ConsoleWritersTest
{
    private Mock<IDirectionsParser> mockDirectionParser;
    private IWriter _writer;
    
    [SetUp]
    public void SetUp()
    {
        mockDirectionParser = new Mock<IDirectionsParser>();
        mockDirectionParser.Setup(parser => parser.UnParse(It.IsAny<NorthDirection>())).Returns("N");
        _writer = new ConsoleWriter(mockDirectionParser.Object);
    }

    [Test]
    public void ConsoleWriterShouldWriteDataInConsole()
    {
        var rover = new Rover(new Plateau(5, 5), 1, 2, new NorthDirection());
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _writer.Write(rover);
        Assert.That(stringWriter.ToString().Trim(), Is.EqualTo("Rover Output: 1 2 N"));
    }
}