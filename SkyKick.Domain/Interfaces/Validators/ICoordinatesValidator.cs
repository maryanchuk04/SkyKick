namespace SkyKick.Domain.Interfaces.Validators;

public interface ICoordinatesValidator
{
    void Validate(int x, int y);
}