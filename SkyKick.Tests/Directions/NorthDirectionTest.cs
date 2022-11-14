using NUnit.Framework;
using SkyKick.Domain.Models;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Directions;

[TestFixture]
public class NorthDirectionTest
{
    private NorthDirection? _direction;

    [SetUp]
    public void SetUp()
    {
        _direction = new NorthDirection();
    }

    [Test]
    public void NorthDirectionRotateLeftTrue()
    {
        var direction = _direction?.RotateLeft();
        Assert.That(direction?.GetType(), Is.EqualTo(new WestDirection().GetType()));
    }

    [Test]
    public void NorthDirectionRotateRightTrue()
    {
        var direction = _direction?.RotateRight();
        Assert.That(direction?.GetType(), Is.EqualTo(new EastDirection().GetType()));
    }

    [Test]
    public void NorthDirectionMoveUpTrue()
    {
        var rover = new Rover(new Plateau(5, 5), 1, 2, new EastDirection());
        _direction?.MoveUp(rover);
        Assert.That(rover.Y, Is.EqualTo(3));
    }
}