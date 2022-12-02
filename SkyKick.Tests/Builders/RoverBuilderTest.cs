using Moq;
using NUnit.Framework;
using SkyKick.Domain.Interfaces.Parsers;
using SkyKick.Domain.Interfaces.Providers;
using SkyKick.Domain.Interfaces.Validators;
using SkyKick.Domain.Models;
using SkyKick.Services.Builders;

namespace SkyKick.Tests.Builders;

[TestFixture]
public class RoverBuilderTest
{
    private RoverBuilder _roverBuilder;
    private Mock<ICoordinateProvider> mockCoordinateProvider = new Mock<ICoordinateProvider>();
    private Mock<IDirectionProvider> mockDirectionProvider = new Mock<IDirectionProvider>();
    private Mock<IDirectionsParser> mockDirectionsParser = new Mock<IDirectionsParser>();
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