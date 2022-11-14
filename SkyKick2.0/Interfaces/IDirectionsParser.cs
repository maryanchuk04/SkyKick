namespace SkyKick2._0.Interfaces;

public interface IDirectionsParser
{
    IDirection Parse(char direction);

    string UnParse(IDirection direction);
}