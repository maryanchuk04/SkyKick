using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
    private Mock<ICommandsProvider> mockCommandsProvider = new ();
    private Mock<IParser<List<ICommand>, List<char>>> mockCommandsParser = new ();

    private readonly List<char> _providedCharsList = new()
    {
        'L', 'M','L','R','L', 'L'
    };

    private readonly List<ICommand> _expectedCommands = new()
    {
        new RotateLeftCommand(),
        new MoveUpCommand(),
        new RotateLeftCommand(),
        new RotateRightCommand(),
        new RotateLeftCommand(),
        new RotateLeftCommand()
    };

    [Test]
    public void Should_Return_NotNullList()
    {
        SetupMocks(new List<char>{'N'}, new List<ICommand> { new RotateLeftCommand()});
        var res = _commandsBuilder.Build();

        Assert.True(res.Any());
    }

    [Test]
    public void Should_Return_ExpectedList()
    {
        SetupMocks(_providedCharsList, _expectedCommands);
        var res = _commandsBuilder.Build();

        Assert.That(res.Count, Is.EqualTo(_expectedCommands.Count));
    }

    [Test]
    public void Should_Return_IncorrectData()
    {
        SetupMocks(null, new List<ICommand>{new MoveUpCommand()});
        var res = _commandsBuilder.Build();

        CollectionAssert.AreNotEqual(res, _expectedCommands);
    }


    private void SetupMocks(List<char> providedList, List<ICommand> commandsList)
    {
        mockCommandsProvider.Setup(x => x.Provide()).Returns(providedList);
        mockCommandsParser.Setup(x => x.Parse(mockCommandsProvider.Object.Provide())).Returns(commandsList);
        _commandsBuilder = new CommandsBuilder(mockCommandsProvider.Object, mockCommandsParser.Object);
    }
}