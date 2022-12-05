using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;
using SkyKick.Services.Interfaces;
using SkyKick.Services.Interfaces.Providers;

namespace SkyKick.Services.Builders;

public class PlateauBuilder : IBuilder<IPlateau>
{
    private readonly ICoordinateProvider _coordinateProvider;
    private readonly ICoordinatesValidator _coordinatesValidator;
    
    public PlateauBuilder(ICoordinateProvider coordinateProvider, ICoordinatesValidator coordinatesValidator)
    {
        _coordinateProvider = coordinateProvider;
        _coordinatesValidator = coordinatesValidator;
    }
    
    public IPlateau Build()
    {
        var coordinates = _coordinateProvider.Provide();
        _coordinatesValidator.Validate(coordinates.Item1, coordinates.Item2);
        return new Plateau(coordinates.Item1, coordinates.Item2);
    }
}