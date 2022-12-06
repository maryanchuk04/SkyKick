
using NUnit.Framework;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class CommandParserTest
{
    private static readonly List<char> testCase = new()
    {
        'M', 'M', 'R', 'M', 'M', 'M', 'R', 'R', 'M'
    };

    [Test]
    public void Should_Return_SameAmountCommands()
    {
        var commandParser = new CommandParser();
        var list = commandParser.Parse(testCase);
        Assert.That(testCase, Has.Count.EqualTo(list.Count));
    }

    [Test]
    public void Should_Return_NotCorrectList()
    {
        var commands = new List<char> {'L', 'M', 'L'};
        var commandParser = new CommandParser();
        var list = commandParser.Parse(testCase);
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