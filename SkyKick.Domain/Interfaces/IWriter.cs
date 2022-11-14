using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IWriter
{
    void Write(Rover rover);
}