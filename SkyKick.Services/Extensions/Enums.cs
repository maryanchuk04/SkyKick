namespace SkyKick.Services.Extensions;

public static class Enums
{
    public static T Next<T>(this T value) where T : struct
    {
        return Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
            .SkipWhile(t => !value.Equals(t)).Skip(1)
            .First();
    }

    public static T Previous<T>(this T value) where T : struct
    {
        return Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) }).Reverse()
            .SkipWhile(t => !value.Equals(t))
            .Skip(1).First();
    }
}