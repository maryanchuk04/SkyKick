using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IReader<T>
    where T : class
{
    T Read();
}