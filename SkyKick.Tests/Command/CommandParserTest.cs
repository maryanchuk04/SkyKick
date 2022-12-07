
using NUnit.Framework;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class CommandParserTest
{
    [Test]
    public void Should_Return_SameAmountCommands()
    {
        List<char> sut = new()
        {
            'M', 'M', 'R', 'M', 'M', 'M', 'R', 'R', 'M'
        };
        
        var commandParser = new CommandParser();
        var list = commandParser.Parse(sut);
        Assert.That(sut, Has.Count.EqualTo(list.Count));
    }

    [Test]
    public void Should_Return_NotCorrectList()
    {
        List<char> sut = new()
        {
            'M', 'M', 'R', 'M', 'M', 'M', 'R', 'R', 'M'
        };
        
        var commands = new List<char> {'L', 'M', 'L'};
        var commandParser = new CommandParser();
        var list = commandParser.Parse(sut);
        Assert.That(commands, Has.Count.Not.EqualTo(list.Count));
    }

    [Test]
    public void Should_Throws_KeyNotFoundException()
    {
        var commands = new List<char> {'X', 'S', 'L'};
        var commandParser = new CommandParser();
        Assert.Throws<KeyNotFoundException>(() =>
        {
            commandParser.Parse(commands);
        });
    }
}