using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;
using SkyKick.Services.Extensions;

namespace SkyKick.Tests.Command;

public class RotateRightCommandTest
{
    private RotateRightCommand _rotateRight;
    private Mock<IRover> rover = new();
    [SetUp]
    public void SetUp()
    {
        _rotateRight = new RotateRightCommand();
    }

    [Test]
    [TestCase(Direction.N, Direction.E)]
    [TestCase(Direction.W, Direction.N)]
    [TestCase(Direction.S, Direction.W)]
    [TestCase(Direction.E, Direction.S)]
    public void Should_Return_TrueObject(Direction direction, Direction expectedDirection)
    {
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _rotateRight.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.EqualTo(expectedDirection));
    }

    [Test]
    [TestCase(Direction.E)]
    [TestCase(Direction.S)]
    [TestCase(Direction.N)]
    [TestCase(Direction.W)]
    public void Should_Return_IncorrectDirectionOfRover(Direction direction)
    {
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _rotateRight.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.Not.EqualTo(direction));
    }
}