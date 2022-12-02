namespace SkyKick.Domain.Interfaces.Parsers;

public interface IParser<TIn, TOut>
{ 
    TIn Parse(TOut provider);
}