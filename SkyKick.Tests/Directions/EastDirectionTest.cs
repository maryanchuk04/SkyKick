using NUnit.Framework;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Directions;

[TestFixture]
public class EastDirectionTest
{
    private EastDirection? _direction;

    [SetUp]
    public void SetUp()
    {
        _direction = new EastDirection();
    }
    
    [Test]
    public void EastDirectionRotateLeftTrue()
    {
        var direction = _direction?.RotateLeft();
        Assert.That(direction?.GetType(), Is.EqualTo(new NorthDirection().GetType()));
    }
    
    [Test]
    public void EastDirectionRotateRightTrue()
    {
        var direction = _direction?.RotateRight();
        Assert.That(direction?.GetType(), Is.EqualTo(new SouthDirection().GetType()));
    }
    
    [Test]
    public void EastDirectionMoveUpTrue()
    {
        var rover = new Rover(new Plateau(5, 5), 1, 2, new EastDirection());
        _direction?.MoveUp(rover);
        Assert.That(rover.X, Is.EqualTo(2));
    }
}