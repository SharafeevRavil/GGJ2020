using DefaultNamespace;

public class ElectricMovableBlock : MovableBlock, IElectricBlock
{
    public bool CheckRecursionActivated => true;
    
    
    public void EnsureDisabled(bool visited)
    {
        if (!visited)
        {
            GetComponent<BlockMaterialChanger>().ChangeMaterial(false);
        }
        else
        {
            GetComponent<BlockMaterialChanger>().ChangeMaterial(true);
        }
    }
}