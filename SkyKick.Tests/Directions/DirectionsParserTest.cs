using Moq;
using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
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
    [TestCase('E')]
    public void ParseShouldReturnTrueValue(char direction)
    {
        var res = _directionsParser.Parse(direction);
        Assert.That(res, Is.EqualTo(Direction.E));
    }

}