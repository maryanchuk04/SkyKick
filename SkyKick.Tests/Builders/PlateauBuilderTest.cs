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
    private readonly Mock<ICoordinateProvider> _coordinatesProviderMock = new ();
    private readonly Mock<ICoordinatesValidator> _coordinatesValidatorMock = new ();

    [SetUp]
    public void SetUp()
    {
        _plateauBuilder = new PlateauBuilder(_coordinatesProviderMock.Object, _coordinatesValidatorMock.Object);
    }

    [Test]
    public void Should_Return_NewPlateau()
    {
        var res = _plateauBuilder.Build();
        Assert.That(res.GetType(), Is.EqualTo(typeof(Plateau)));
    }

    [Test]
    public void Should_Return_NewPlateauWithCorrectData()
    {
        var sut = new Plateau(5, 5);
        _coordinatesProviderMock.Setup(x => x.Provide()).Returns((5, 5));
        var res = _plateauBuilder.Build();
        Assert.Multiple(() =>
        {
            Assert.That(res.UpperBoundX, Is.EqualTo(sut.UpperBoundX));
            Assert.That(res.UpperBoundY, Is.EqualTo(sut.UpperBoundY));
        });
    }

    [Test]
    [TestCase(1,1)]
    [TestCase(4,4)]
    [TestCase(12,1)]
    public void Should_Return_NewPlateauWithInCorrectData(int testValue1, int testValue2)
    {
        var sut = new Plateau(5, 5);
        _coordinatesProviderMock.Setup(x => x.Provide()).Returns((testValue1, testValue2));
        var res = _plateauBuilder.Build();
        Assert.Multiple(() =>
        {
            Assert.That(res.UpperBoundX, Is.Not.EqualTo(sut.UpperBoundX));
            Assert.That(res.UpperBoundY, Is.Not.EqualTo(sut.UpperBoundY));
        });
    }
}