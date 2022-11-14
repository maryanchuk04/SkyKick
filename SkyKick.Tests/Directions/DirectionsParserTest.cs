using Moq;
using NUnit.Framework;
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
        Assert.That(res.GetType(), Is.EqualTo(new EastDirection().GetType()));
    }

    [Test]
    public void UnParseNotThrowsException()
    {
        IDirection direction = new EastDirection();
        Assert.DoesNotThrow(() =>
        {
            _directionsParser.UnParse(direction);
        });
    }
    
    [Test]
    public void UnParseReturnTrueKey()
    {
        IDirection direction = new EastDirection();
        var res = String.Empty;
        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => res = _directionsParser.UnParse(direction));
            Assert.That(res, Is.EqualTo("E"));
        });
    }
    
    [Test]
    public void UnParseThrowsException()
    {
        var mockDirection = new Mock<IDirection>();

        Assert.Throws<UnParseException>(() =>
        {
            _directionsParser.UnParse(mockDirection.Object);
        });
    }
    
    [Test]
    public void UnParseReturnString()
    {
        IDirection direction = new EastDirection();
        var res = _directionsParser.UnParse(direction);
        Assert.That(res, Is.EqualTo("E"));
    }
}
