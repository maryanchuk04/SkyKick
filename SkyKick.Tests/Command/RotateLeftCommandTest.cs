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
    public void RotateLeftShodReturnTrueObject()
    {
        var rover = new Mock<IRover>();
        rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, Direction.E));
        _leftCommand.Execute(rover.Object);
        Assert.That(rover.Object.CurrentPosition.Direction, Is.EqualTo(Direction.N));
    }
}