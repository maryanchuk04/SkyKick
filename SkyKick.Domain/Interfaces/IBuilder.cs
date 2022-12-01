namespace SkyKick.Domain.Interfaces;

public interface IBuilder<T>
    where T : class
{
    T Build();
}