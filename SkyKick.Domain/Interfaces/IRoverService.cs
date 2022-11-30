namespace SkyKick.Domain.Interfaces;

public interface IRoverService
{
    public IPlateau? Plateau { get; set; }
    public IRover? Rover { get; set; }
    void ExecuteCommands(List<ICommand> commands);
    void OutputResults();
}