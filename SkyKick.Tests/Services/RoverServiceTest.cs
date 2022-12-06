using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services;
using SkyKick.Services.Command;
using SkyKick.Services.Interfaces;


namespace SkyKick.Tests.Services;

[TestFixture]
public class RoverServiceTest
{
    private Mock<IWriter> _writer = new ();
    private Mock<IRover> _rover = new ();
    private Mock<IPlateau> _plateau = new ();
    private RoverService _roverService;

    [SetUp]
    public void SetUp()
    {
        _plateau.Setup(x => x.UpperBoundX).Returns(5);
        _plateau.Setup(x => x.UpperBoundY).Returns(5);
        _rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, Direction.N));
        _roverService = new RoverService(_writer.Object)
        {
            Rover = _rover.Object,
            Plateau = _plateau.Object
        };
    }

    [Test(Description = "First test from example! Movement plan 'LMLMLMLMM'")]
    public void Should_Return_CorrectDataFirst()
    {
        _roverService.ExecuteCommands(GetTestCommands());
        Assert.Multiple(() =>
        {
            Assert.That(_rover.Object.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(_rover.Object.CurrentPosition.Y, Is.EqualTo(3));
            Assert.That(_rover.Object.CurrentPosition.Direction, Is.EqualTo(Direction.N));
        });
    }

    [Test(Description = "Second test from example! Movement plan 'MMRMMRMRRM'")]
    public void Should_Return_CorrectDataSecond()
    {
        _rover.Setup(x => x.CurrentPosition).Returns(new Position(3, 3, Direction.E));
        _roverService = new RoverService(null)
        {
            Rover = _rover.Object,
            Plateau = _plateau.Object
        };
        _roverService.ExecuteCommands(GetTestCommands_SecondExample());
        Assert.Multiple(() =>
        {
            Assert.That(_rover.Object.CurrentPosition.X, Is.EqualTo(5));
            Assert.That(_rover.Object.CurrentPosition.Y, Is.EqualTo(1));
            Assert.That(_rover.Object.CurrentPosition.Direction, Is.EqualTo(Direction.E));
        });
    }

    [Test]
    public void Should_DoesNotThrows()
    {
        Assert.DoesNotThrow(() =>
        {
            _roverService.ExecuteCommands(GetTestCommands());
        });
    }

    [Test]
    public void Should_Throws_RoverCoordinatesOutBoundsException()
    {
        _rover.Setup(x => x.CurrentPosition).Returns(new Position(5, 5, Direction.N));
        Assert.Throws<RoverCoordinatesOutBoundsException>(() =>
        {
            _roverService.ExecuteCommands(GetTestCommands());
        });
    }

    [Test]
    public void Should_DoesNotThrowsAnyExceptions()
    {
        Assert.DoesNotThrow(() =>
        {
            _roverService.OutputResults();
        });
    }

    [Test]
    public void Should_RoverOrPlateauIsNull_Throws_NullReferenceException()
    {
        _rover = new Mock<IRover>();
        _plateau = new Mock<IPlateau>();
        _roverService = new RoverService(null);
        Assert.Throws<NullReferenceException>(() =>
        {
            _roverService.ExecuteCommands(GetTestCommands());
        });
    }

    private List<ICommand> GetTestCommands()
    {
        return new List<ICommand>()
        {
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new MoveUpCommand(),
        };
    }

    private List<ICommand> GetTestCommands_SecondExample()
    {
        return new List<ICommand>()
        {
            new MoveUpCommand(),
            new MoveUpCommand(),
            new RotateRightCommand(),
            new MoveUpCommand(),
            new MoveUpCommand(),
            new RotateRightCommand(),
            new MoveUpCommand(),
            new RotateRightCommand(),
            new RotateRightCommand(),
            new MoveUpCommand()
        };
    }

}