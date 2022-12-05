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
    private Mock<ICoordinateProvider> mockCoordinateProvider = new Mock<ICoordinateProvider>();
    private Mock<IDirectionProvider> mockDirectionProvider = new Mock<IDirectionProvider>();
    private Mock<IParser<Direction, char>> mockDirectionsParser = new Mock<IParser<Direction, char>>();
    private Mock<ICoordinatesValidator> mockCoordinatesValidator = new Mock<ICoordinatesValidator>();

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
}