
using NUnit.Framework;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class CommandParserTest
{
    private static readonly List<char> TestCase = new List<char>()
    {
        'M', 'M', 'R', 'M', 'M', 'M', 'R', 'R', 'M'
    };
    
    [Test]
    public void Should_Return_SameAmountCommands()
    {
        var commandParser = new CommandParser();
        var list = commandParser.Parse(TestCase);
        Assert.That(TestCase, Has.Count.EqualTo(list.Count));
    }
}