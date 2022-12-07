using NUnit.Framework;
using SkyKick.Domain.Exceptions;
using SkyKick.Services.Validators;

namespace SkyKick.Tests.Validators;

[TestFixture]
public class CoordinatesValidatorsTest
{
    private CoordinatesValidator _coordinatesValidator;

    [SetUp]
    public void SetUp()
    {
        _coordinatesValidator = new CoordinatesValidator();
    }

    [Test] 
    [TestCase(-1, -1)] 
    [TestCase(0, -1)]
    public void Should_Throws_InvalidCoordinates_IncorrectInputData(int x, int y)
    {
        Assert.Throws<IncorrectInputDataException>(() =>
        {
            _coordinatesValidator.Validate(x,y);
        });
    }
    
    [Test]
    [TestCase(5,5)]
    [TestCase(4,4)]
    public void Should_DoestNotThrows_ValidCoordinates(int x, int y)
    {
        Assert.DoesNotThrow(() =>
        {
            _coordinatesValidator.Validate(x,y);
        });
    }
}