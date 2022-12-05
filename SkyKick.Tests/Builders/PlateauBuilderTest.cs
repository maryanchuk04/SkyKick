using Moq;
using NUnit.Framework;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Builders;
using SkyKick.Services.Interfaces;
using SkyKick.Services.Interfaces.Providers;

namespace SkyKick.Tests.Builders;

[TestFixture]
public class PlateauBuilderTest
{
    private PlateauBuilder _plateauBuilder;
    private readonly Mock<ICoordinateProvider> _coordinatesProviderMock = new Mock<ICoordinateProvider>();
    private readonly Mock<ICoordinatesValidator> _coordinatesValidatorMock = new Mock<ICoordinatesValidator>();

    [SetUp]
    public void SetUp()
    {
        _plateauBuilder = new PlateauBuilder(_coordinatesProviderMock.Object, _coordinatesValidatorMock.Object);
    }

    [Test] public void Should_Return_NewPlateau()
    {
        var res = _plateauBuilder.Build();
        Assert.That(res.GetType(), Is.EqualTo(typeof(Plateau)));
    }
}