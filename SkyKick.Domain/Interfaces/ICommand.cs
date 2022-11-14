

using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface ICommand
{
    void Execute(Rover rover);
}