namespace SkyKick.Services.Interfaces.Providers;

public interface ICoordinateProvider
{
    (int, int) Provide();
}