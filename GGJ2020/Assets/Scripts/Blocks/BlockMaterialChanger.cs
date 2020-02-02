using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaterialChanger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;


    public void ChangeMaterial(bool enabled)
    {
        GetComponent<MeshRenderer>().material = enabled ? enabledMaterial : disabledMaterial;
    }

    public Material disabledMaterial;
    public Material enabledMaterial;
}