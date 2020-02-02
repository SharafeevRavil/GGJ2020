using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricReceiverBlock : Block, IElectricBlock
{
    public bool CheckRecursionActivated
    {
        get
        {
            blockLevel.ReceiverHasEnabled();
            return true;
        }
    }
    
    public void EnsureDisabled(bool visited)
    {
    }
}