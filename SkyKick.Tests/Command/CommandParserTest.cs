
using NUnit.Framework;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class CommandParserTest
{
    [Test]
    [TestCase("LMLMLMLMM")]
    [TestCase("MMRMMRMRRM")]
    public void ParseShouldReturnSameAmountCommands(string commandString)
    {
        var commandParser = new CommandParser();
        var list = commandParser.Parse(commandString);
        Assert.That(commandString, Has.Length.EqualTo(list.Count));
    }
}