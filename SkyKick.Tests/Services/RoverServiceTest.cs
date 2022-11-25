using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services;
using SkyKick.Services.Command;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Services;

[TestFixture]
public class RoverServiceTest
{
    private IRoverService _roverService;
    private Rover _rover;
    private List<ICommand> _commands;
    private Rover roverAfterExecution;
    private Plateau _plateau;

    [SetUp]
    public void SetUp()
    {
        _plateau = new Plateau(5, 5);
        _roverService = new RoverService(); 
        _rover = new Rover(1, 2, Direction.N);
        _commands = new List<ICommand>()
        {
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new RotateLeftCommand(),
            new MoveUpCommand(),
            new MoveUpCommand(),
        };
        roverAfterExecution = new Rover(1, 3, Direction.N);

    }
    
    [Test]
    public void ExecuteCommandsTrueExecution()
    { 
        _roverService.Rover = _rover;
        _roverService.Plateau = _plateau;
        _roverService.ExecuteCommands(_commands);
        Assert.Multiple(() =>
        {
            Assert.That(roverAfterExecution.X, Is.EqualTo(_rover.X));
            Assert.That(roverAfterExecution.Y, Is.EqualTo(_rover.Y));
            Assert.That(roverAfterExecution.Direction, Is.EqualTo(_rover.Direction));
        });
    }
}