using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Interfaces.Providers;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Readers;

public class RoverBuilder : IReader<IRover>
{
    private readonly ICoordinateProvider _coordinateProvider;
    private readonly IDirectionProvider _directionProvider;
    
    public RoverBuilder(ICoordinateProvider coordinateProvider, IDirectionProvider directionProvider)
    {
        _coordinateProvider = coordinateProvider;
        _directionProvider = directionProvider;
    }
    
    public IRover Read()
    {
        var coordinates = _coordinateProvider.Provide();
        var direction = _directionProvider.Provide();
        
        return new Rover(new Position(coordinates.Item1, coordinates.Item2, direction));
    }
}