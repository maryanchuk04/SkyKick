using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Command;

[TestFixture]
public class RotateRightCommandTest
{
    [Test]
    public void RotateRightShodReturnTrueObject()
    {
        var rover = new Rover(1, 2, Direction.N);
        var rotateLeftCommand = new RotateRightCommand();
        rotateLeftCommand.Execute(rover);
        Assert.That(rover.Direction, Is.EqualTo(Direction.E));
    }
}