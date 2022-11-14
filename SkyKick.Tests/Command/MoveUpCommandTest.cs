using NUnit.Framework;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Command;

[TestFixture]
public class MoveUpCommandTest
{
    private Plateau _plateau;
    private Rover badRovever;
    private Rover goodRover;

    [SetUp]
    public void SetUp()
    {
        _plateau = new Plateau(5, 5);
        badRovever = new Rover(_plateau, 5, 5, new NorthDirection());
        goodRover = new Rover(_plateau, 1, 2, new EastDirection());
    }

    [Test]
    public void ExecuteMoveUp_Throws()
    {
        var moveUpCommand = new MoveUpCommand();
        Assert.Throws<RoverCoordinatesOutBoundsException>(() =>
        {
            moveUpCommand.Execute(badRovever);
        });
    }
    
    [Test]
    public void ExecuteMoveUpGood()
    {
        var moveUpCommand = new MoveUpCommand();
        moveUpCommand.Execute(goodRover);
        Assert.That(goodRover.X, Is.EqualTo(2));
    }
}