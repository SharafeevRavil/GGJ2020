using DefaultNamespace;

public class ElectricMovableBlock : MovableBlock, IElectricBlock
{
    public bool IsActivated => true;
}