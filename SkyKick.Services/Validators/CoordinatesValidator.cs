using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;
using SkyKick.Services.Interfaces;

namespace SkyKick.Services.Validators;

public class CoordinatesValidator : ICoordinatesValidator
{
    public void Validate(int x, int y)
    {
        if (x <= IPlateau.LowerBoundX || y <= IPlateau.LowerBoundY)
            throw new IncorrectInputDataException("Input coordinates is not correct!");
    }
}