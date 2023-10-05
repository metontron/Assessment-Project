using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlock : Block
{
    public override void ActivatePhysics()
    {
        gameObject.SetActive(false);
    }
}