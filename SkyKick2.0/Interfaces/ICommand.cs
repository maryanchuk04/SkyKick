using SkyKick2._0.Models;

namespace SkyKick2._0.Interfaces;

public interface ICommand
{
    void Execute(Rover rover);
}