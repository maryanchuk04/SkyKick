using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Parsers;
using SkyKick.Domain.Interfaces.Providers;
using SkyKick.Domain.Interfaces.Validators;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Builders;

public class RoverBuilder : IBuilder<IRover>
{
    private readonly ICoordinateProvider _coordinateProvider;
    private readonly IDirectionProvider _directionProvider;
    private readonly IParser<Direction, char> _directionsParser;
    private readonly ICoordinatesValidator _coordinatesValidator;
    
    public RoverBuilder(ICoordinateProvider coordinateProvider, IDirectionProvider directionProvider, IParser<Direction, char> directionsParser, ICoordinatesValidator coordinatesValidator)
    {
        _coordinateProvider = coordinateProvider;
        _directionProvider = directionProvider;
        _directionsParser = directionsParser;
        _coordinatesValidator = coordinatesValidator;
    }
    
    public IRover Build()
    {
        var coordinates = _coordinateProvider.Provide();
        var direction = _directionsParser.Parse(_directionProvider.Provide());
        _coordinatesValidator.Validate(coordinates.Item1, coordinates.Item2);
        return new Rover(new Position(coordinates.Item1, coordinates.Item2, direction));
    }
}