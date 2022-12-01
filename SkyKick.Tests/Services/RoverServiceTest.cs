using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services;
using SkyKick.Services.Command;


namespace SkyKick.Tests.Services;

[TestFixture]
public class RoverServiceTest
{
    private Mock<IWriter> _writer = new Mock<IWriter>();
    private readonly Mock<IRover> _rover = new Mock<IRover>();
    private readonly Mock<IPlateau> _plateau = new Mock<IPlateau>();
    private RoverService _roverService;
    
    [SetUp]
    public void SetUp()
    {
        _plateau.Setup(x => x.UpperBoundX).Returns(5);
        _plateau.Setup(x => x.UpperBoundY).Returns(5);
        _rover.Setup(x => x.CurrentPosition).Returns(new Position(1, 2, Direction.N));
        _roverService = new RoverService(_writer.Object)
        {
            Rover = _rover.Object,
            Plateau = _plateau.Object
        };
    }
    
    [Test]
    public void ExecuteCommandsTrueExecution()
    {
        Assert.DoesNotThrow(() =>
        {
            _roverService.ExecuteCommands(GetTestCommands());
        });
    }

    private List<ICommand> GetTestCommands()
    {
        return new List<ICommand>()
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
    }
    
}