using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

public class RotateRightCommandTest
{
    private RotateRightCommand _rotateRight;

    [SetUp]
    public void SetUp()
    {
        _rotateRight = new RotateRightCommand();
    }

    [Test]
    public void Should_Return_TrueObject()
    {
        var rover = new Mock<IRover>();
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, Direction.N));
        _rotateRight.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.EqualTo(Direction.E));
    }

    [Test]
    [TestCase(Direction.E)]
    [TestCase(Direction.S)]
    [TestCase(Direction.N)]
    public void Should_Return_IncorrectDirectionOfRover(Direction direction)
    {
        var rover = new Mock<IRover>();
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _rotateRight.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.Not.EqualTo(Direction.N));
    }
}