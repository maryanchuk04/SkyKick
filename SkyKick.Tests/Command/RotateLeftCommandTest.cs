using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class RotateLeftCommandTest
{
    private RotateLeftCommand _leftCommand;
    private Mock<IRover> rover = new();
    
    [SetUp]
    public void SetUp()
    {
        _leftCommand = new RotateLeftCommand();
    }

    [Test]
    [TestCase(Direction.E, Direction.N)]
    [TestCase(Direction.S, Direction.E)]
    [TestCase(Direction.W, Direction.S)]
    [TestCase(Direction.N, Direction.W)]
    public void Should_Return_TrueDirectionOfRover(Direction direction, Direction expectedDirection)
    {
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.EqualTo(expectedDirection));
    }

    [Test]
    [TestCase(Direction.N, Direction.E)]
    [TestCase(Direction.W, Direction.N)]
    [TestCase(Direction.S, Direction.W)]
    [TestCase(Direction.E, Direction.S)]
    public void Should_Return_IncorrectDirectionOfRover(Direction direction, Direction expectedDirection)
    {
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.Not.EqualTo(expectedDirection));
    }
}
