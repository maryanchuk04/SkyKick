using Moq;
using NUnit.Framework;
using SkyKick.Domain.Interfaces;
using SkyKick.Services.Builders;
using SkyKick.Services.Command;
using SkyKick.Services.Interfaces;
using SkyKick.Services.Interfaces.Providers;

namespace SkyKick.Tests.Builders;

[TestFixture]
public class CommandsBuilderTest
{
    private CommandsBuilder _commandsBuilder;
    private Mock<ICommandsProvider> mockCommandsProvider = new Mock<ICommandsProvider>();
    private Mock<IParser<List<ICommand>, List<char>>> mockCommandsParser =
        new Mock<IParser<List<ICommand>, List<char>>>();

    [Test]
    public void Should_Return_NotNullList()
    {
        mockCommandsProvider.Setup(x => x.Provide()).Returns(new List<char>(){'N'});

        mockCommandsParser.Setup(x => x.Parse(mockCommandsProvider.Object.Provide())).Returns(new List<ICommand>
        {
            new RotateLeftCommand()
        });
        
        _commandsBuilder = new CommandsBuilder(mockCommandsProvider.Object, mockCommandsParser.Object);
        
        var res = _commandsBuilder.Build();
        Assert.True(res.Any());
    } 
}