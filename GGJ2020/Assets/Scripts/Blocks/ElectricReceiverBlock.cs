using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricReceiverBlock : Block, IElectricBlock
{
    public bool IsActivated
    {
        get
        {
            blockLevel.ReceiverHasEnabled();
            return true;
        }
    }
}