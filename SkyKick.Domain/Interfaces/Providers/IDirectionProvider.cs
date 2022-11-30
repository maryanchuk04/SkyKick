using SkyKick.Domain.Enum;

namespace SkyKick.Domain.Interfaces.Providers;

public interface IDirectionProvider
{
    Direction Provide();
}