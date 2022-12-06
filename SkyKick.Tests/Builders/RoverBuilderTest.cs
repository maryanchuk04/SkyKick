using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Models;
using SkyKick.Services.Builders;
using SkyKick.Services.Interfaces;
using SkyKick.Services.Interfaces.Providers;

namespace SkyKick.Tests.Builders;

[TestFixture]
public class RoverBuilderTest
{
    private RoverBuilder _roverBuilder;
    private Mock<ICoordinateProvider> mockCoordinateProvider = new ();
    private Mock<IDirectionProvider> mockDirectionProvider = new ();
    private Mock<IParser<Direction, char>> mockDirectionsParser = new ();
    private Mock<ICoordinatesValidator> mockCoordinatesValidator = new ();

    [SetUp]
    public void SetUp()
    {
        _roverBuilder = new RoverBuilder(mockCoordinateProvider.Object,
            mockDirectionProvider.Object,
            mockDirectionsParser.Object,
            mockCoordinatesValidator.Object);
    }

    [Test]
    public void Should_Return_NewRover()
    {
        var res = _roverBuilder.Build();
        Assert.That(res.GetType(), Is.EqualTo(typeof(Rover)));
    }

    [Test]
    public void Should_Return_NewRoverCorrectData()
    {
        mockCoordinateProvider.Setup(x => x.Provide()).Returns((1, 1));
        mockDirectionsParser.Setup(x => x.Parse('N')).Returns(Direction.N);
        _roverBuilder = new RoverBuilder(mockCoordinateProvider.Object,
            mockDirectionProvider.Object,
            mockDirectionsParser.Object,
            mockCoordinatesValidator.Object);
        var res = _roverBuilder.Build();

        Assert.Multiple(() =>
        {
            Assert.That(res.CurrentPosition.Direction, Is.EqualTo(Direction.N));
            Assert.That(res.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(res.CurrentPosition.Y, Is.EqualTo(1));
        });
    }

    [Test]
    [TestCase(1,1,'E')]
    [TestCase(2,2,'W')]
    [TestCase(1,3,'S')]
    public void Should_Return_NewRoverIncorrectData(int x, int y, char direction)
    {
        mockCoordinateProvider.Setup(x => x.Provide()).Returns((1, 1));
        mockDirectionsParser.Setup(x => x.Parse(direction)).Returns(Direction.N);
        _roverBuilder = new RoverBuilder(mockCoordinateProvider.Object,
            mockDirectionProvider.Object,
            mockDirectionsParser.Object,
            mockCoordinatesValidator.Object);
        var res = _roverBuilder.Build();

        Assert.Multiple(() =>
        {
            Assert.That(res.CurrentPosition.Direction, Is.EqualTo(Direction.N));
            Assert.That(res.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(res.CurrentPosition.Y, Is.EqualTo(1));
        });
    }

}