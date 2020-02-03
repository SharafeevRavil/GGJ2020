using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ElectricGeneratorBlock : Block, IElectricBlock
{
    public bool CheckRecursionActivated => true;
    
    public void EnsureDisabled(bool visited)
    {
    }
}
