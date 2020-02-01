using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWireBlock : Block, IElectricBlock
{
    public bool IsActivated => true;
}
