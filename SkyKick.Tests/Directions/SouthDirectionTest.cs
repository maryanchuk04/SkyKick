using NUnit.Framework;
using SkyKick.Domain.Models;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Directions;

[TestFixture]
public class SouthDirectionTest
{
    private SouthDirection? _direction;

    [SetUp]
    public void SetUp()
    {
        _direction = new SouthDirection();
    }
    
    [Test]
    public void EastDirectionRotateLeftTrue()
    {
        var direction = _direction?.RotateLeft();
        Assert.That(direction?.GetType(), Is.EqualTo(new EastDirection().GetType()));
    }
    
    [Test]
    public void EastDirectionRotateRightTrue()
    {
        var direction = _direction?.RotateRight();
        Assert.That(direction?.GetType(), Is.EqualTo(new WestDirection().GetType()));
    }
    
    [Test]
    public void EastDirectionMoveUpTrue()
    {
        var rover = new Rover(new Plateau(5, 5), 1, 2, new EastDirection());
        _direction?.MoveUp(rover);
        Assert.That(rover.Y, Is.EqualTo(1));
    }
}