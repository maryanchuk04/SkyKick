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

    [Test]
    public void Should_Return_IncorrectPreviousItem()
    {
        const Direction direction = Direction.N;
        var next = direction.Previous();
        Assert.That(next, Is.Not.EqualTo(Direction.S));
    }

    [Test]
    public void Should_Return_IncorrectNextItem()
    {
        const Direction direction = Direction.N;
        var next = direction.Next();
        Assert.That(next, Is.Not.EqualTo(Direction.N));
    }

    [Test]
    [TestCase(Direction.E)]
    [TestCase(Direction.S)]
    [TestCase(Direction.N)]
    [TestCase(Direction.W)]
    public void Next_Should_Return_ToTheSameDirection(Direction direction)
    {
        var sut = direction;
        for (int i = 0; i < 4; i++)
        {
            sut.Next();
        }

        Assert.That(sut, Is.EqualTo(direction));
    }
    
    [Test]
    [TestCase(Direction.E)]
    [TestCase(Direction.S)]
    [TestCase(Direction.N)]
    [TestCase(Direction.W)]
    public void Previous_Should_Return_ToTheSameDirection(Direction direction)
    {
        var sut = direction;
        for (int i = 0; i < 4; i++)
        {
            sut.Previous();
        }

        Assert.That(sut, Is.EqualTo(direction));
    }
}