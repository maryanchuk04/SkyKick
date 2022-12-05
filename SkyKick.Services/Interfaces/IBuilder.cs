namespace SkyKick.Services.Interfaces;

public interface IBuilder<T>
    where T : class
{
    T Build();
}