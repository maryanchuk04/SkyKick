using Moq;
using NUnit.Framework;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Parsers;
using SkyKick.Services;

namespace SkyKick.Tests;

[TestFixture]
public class ConsoleChannelTest
{
    private ConsoleChannel consoleChannel;
    private Mock<IDirectionsParser> directionParserMock = new Mock<IDirectionsParser>();
    private Mock<ICommandParser> commandsParserMock = new Mock<ICommandParser>();
    
    [SetUp]
    public void SetUp()
    {
        consoleChannel = new ConsoleChannel();
    }

    [Test]
    public void CommandProviderProvideShouldByReturnData()
    {
        
    }
}