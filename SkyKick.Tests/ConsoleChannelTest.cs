using Moq;
using NUnit.Framework;
using SkyKick.Domain.Interfaces;
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
        consoleChannel = new ConsoleChannel(directionParserMock.Object, commandsParserMock.Object);
    }

    [Test]
    public void CommandProviderProvideShouldByReturnData()
    {
        
    }
}