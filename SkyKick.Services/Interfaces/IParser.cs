namespace SkyKick.Services.Interfaces;

public interface IParser<TIn, TOut>
{ 
    TIn Parse(TOut provider);
}