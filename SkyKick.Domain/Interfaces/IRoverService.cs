using SkyKick.Domain.Models;

namespace SkyKick.Domain.Interfaces;

public interface IRoverService
{
    public Plateau? Plateau { get; set; }
    public Rover? Rover { get; set; }
    void ExecuteCommands(List<ICommand> commands);
}