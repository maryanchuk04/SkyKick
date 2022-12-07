using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Services.Directions;

namespace SkyKick.Tests.Directions;

[TestFixture]
public class DirectionsParserTest
{
    private DirectionsParser? _directionsParser;

    [SetUp]
    public void SetUp()
    {
        _directionsParser = new DirectionsParser();
    }

    [Test]
    [TestCase('E', Direction.E)]
    [TestCase('W', Direction.W)]
    [TestCase('S', Direction.S)]
    [TestCase('N', Direction.N)]
    public void Should_Return_TrueValueOfDirection(char direction, Direction expectedDirection)
    {
        var res = _directionsParser.Parse(direction);
        Assert.That(res, Is.EqualTo(expectedDirection));
    }

    [Test]
    [TestCase('N')]
    [TestCase('S')]
    public void Should_Return_InvalidValueOfDirection(char direction)
    {
        var res = _directionsParser.Parse(direction);
        Assert.That(res, Is.Not.EqualTo(Direction.W));
    }
}