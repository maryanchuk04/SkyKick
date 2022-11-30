namespace SkyKick.Domain.Interfaces.Providers;

public interface ICoordinateProvider
{
    (int, int) Provide();
}