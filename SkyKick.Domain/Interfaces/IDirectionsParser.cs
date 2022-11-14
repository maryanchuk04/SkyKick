namespace SkyKick.Domain.Interfaces;

public interface IDirectionsParser
{
    IDirection Parse(char direction);

    string UnParse(IDirection direction);
}