using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWireBlock : Block, IElectricBlock
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
