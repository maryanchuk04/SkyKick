using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Providers;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Readers;

public class PlateauBuilder : IReader<IPlateau>
{
    private readonly ICoordinateProvider _coordinateProvider;

    public PlateauBuilder(ICoordinateProvider coordinateProvider)
    {
        _coordinateProvider = coordinateProvider;
    }
    
    public IPlateau Read()
    {
        var coordinates = _coordinateProvider.Provide();
        return new Plateau(coordinates.Item1, coordinates.Item2);
    }
}