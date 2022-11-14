using NUnit.Framework;
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

    [SetUp]
    public void SetUp()
    {
        _roverService = new RoverService(); 
        _rover = new Rover(new Plateau(5, 5), 1, 2, new NorthDirection());
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
        roverAfterExecution = new Rover(new Plateau(5, 5), 1, 3, new NorthDirection());

    }
    
    [Test]
    public void ExecuteCommandsTrueExecution()
    {
        _roverService.ExecuteCommands(_rover, _commands);
        Assert.Multiple(() =>
        {
            Assert.That(roverAfterExecution.X, Is.EqualTo(_rover.X));
            Assert.That(roverAfterExecution.Y, Is.EqualTo(_rover.Y));
            Assert.That(roverAfterExecution.Direction.GetType(), Is.EqualTo(_rover.Direction.GetType()));
        });
    }
}