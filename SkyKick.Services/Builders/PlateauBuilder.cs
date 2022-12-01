using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Providers;
using SkyKick.Domain.Interfaces.Validators;
using SkyKick.Domain.Models;

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