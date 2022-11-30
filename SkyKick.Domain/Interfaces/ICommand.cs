namespace SkyKick.Domain.Interfaces;

public interface ICommand
{
    void Execute(IRover rover);
}