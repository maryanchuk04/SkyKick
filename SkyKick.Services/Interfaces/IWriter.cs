using SkyKick.Domain.Interfaces;

namespace SkyKick.Services.Interfaces;

public interface IWriter
{
    void Write(IRover rover);
}