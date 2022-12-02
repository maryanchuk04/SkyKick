using NUnit.Framework;
using SkyKick.Domain.Enum;
using SkyKick.Services.Extensions;

namespace SkyKick.Tests.Extensions;

[TestFixture]
public class EnumsExtensionTest
{
    [Test]
    public void Should_Return_NextItemInEnum()
    {
        const Direction direction = Direction.N;
        var next = direction.Next();
        Assert.That(next, Is.EqualTo(Direction.E));
    }
    
    [Test]
    public void Should_Return_PreviousItemInEnum()
    {
        const Direction direction = Direction.N;
        var next = direction.Previous();
        Assert.That(next, Is.EqualTo(Direction.W));
    }
}