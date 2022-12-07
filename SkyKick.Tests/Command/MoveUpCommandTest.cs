using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Command;

namespace SkyKick.Tests.Command;

[TestFixture]
public class MoveUpCommandTest
{
    private MoveUpCommand _moveUpCommand;
    private Mock<IRover> _mockRover = new();

    [SetUp]
    public void SetUp()
    {
        _moveUpCommand = new MoveUpCommand();
    }

    [Test]
    public void Should_MoveUpRover_ExecuteDoesNotThrow()
    {
        var startPosition = new Position(1, 1, Direction.N);
        _mockRover.Setup(x => x.CurrentPosition).Returns(startPosition);
        Assert.DoesNotThrow(() =>
        {
            _moveUpCommand.Execute(_mockRover.Object);
        });
    }

    [Test]
    [TestCase(1)]
    [TestCase(4)]
    [TestCase(3)]
    public void Should_MoveUpRover_Return_TrueValues(int y)
    {
        var sut = new Position(1, y, Direction.N);
        var expectedY = sut.Y + 1;
        _mockRover.Setup(x => x.CurrentPosition).Returns(sut);
        _moveUpCommand.Execute(_mockRover.Object);

        Assert.That(_mockRover.Object.CurrentPosition.Y, Is.EqualTo(expectedY));
    }
}