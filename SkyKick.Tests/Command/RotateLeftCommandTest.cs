using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class RotateLeftCommandTest
{
    [Test]
    public void RotateLeftShodReturnTrueObject()
    {
        var rover = new Rover(1, 2,Direction.E);
        var rotateLeftCommand = new RotateLeftCommand();
        rotateLeftCommand.Execute(rover);
        Assert.That(rover.Direction, Is.EqualTo(Direction.N));
    }
}