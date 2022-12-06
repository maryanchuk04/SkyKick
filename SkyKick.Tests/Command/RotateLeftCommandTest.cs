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

    [SetUp]
    public void SetUp()
    {
        _leftCommand = new RotateLeftCommand();
    }

    [Test]
    public void Should_Return_TrueDirectionOfRover()
    {
        var rover = new Mock<IRover>();
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, Direction.E));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.EqualTo(Direction.N));
    }

    [Test]
    [TestCase(Direction.N)]
    [TestCase(Direction.W)]
    [TestCase(Direction.S)]
    public void Should_Return_IncorrectDirectionOfRover(Direction direction)
    {
        var rover = new Mock<IRover>();
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.Not.EqualTo(Direction.N));
    }
}
