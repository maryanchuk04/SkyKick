using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Writers;

namespace SkyKick.Tests.Writers;

[TestFixture]
public class ConsoleWritersTest
{
    private IWriter _writer;
    
    [SetUp]
    public void SetUp()
    {
        _writer = new ConsoleWriter();
    }

    [Test]
    public void ConsoleWriterShouldWriteDataInConsole()
    {
        var rover = new Rover(1, 2, Direction.N);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _writer.Write(rover);
        Assert.That(stringWriter.ToString().Trim(), Is.EqualTo("Rover Output: 1 2 N"));
    }
}