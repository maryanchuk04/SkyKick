using NUnit.Framework;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Command;

[TestFixture]
public class RotateLeftCommandTest
{
    [Test]
    public void RotateLeftShodReturnTrueObject()
    {
        var rover = new Rover(new Plateau(5,5), 1, 2, new EastDirection());
        var rotateLeftCommand = new RotateLeftCommand();
        rotateLeftCommand.Execute(rover);
        Assert.That(rover.Direction.GetType(), Is.EqualTo(new NorthDirection().GetType()));
    }
}