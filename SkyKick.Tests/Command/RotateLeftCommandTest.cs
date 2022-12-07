using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;
using SkyKick.Services.Extensions;

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
    [TestCase(Direction.E)]
    [TestCase(Direction.S)]
    [TestCase(Direction.W)]
    [TestCase(Direction.N)]
    public void Should_Return_TrueDirectionOfRover(Direction direction)
    {
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.EqualTo(direction.Previous()));
    }

    [Test]
    [TestCase(Direction.N)]
    [TestCase(Direction.W)]
    [TestCase(Direction.S)]
    [TestCase(Direction.E)]
    public void Should_Return_IncorrectDirectionOfRover(Direction direction)
    {
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, direction));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.Not.EqualTo(direction));
    }
}
