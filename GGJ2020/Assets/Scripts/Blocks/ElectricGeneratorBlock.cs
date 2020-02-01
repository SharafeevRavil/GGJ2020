using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ElectricGeneratorBlock : Block, IElectricBlock
{
    public bool IsActivated => true;
}
