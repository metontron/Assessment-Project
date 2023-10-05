using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlock
{
    public void SetConcept(IConcept concept);

    public IConcept GetConcept();

    public void ActivatePhysics();
}