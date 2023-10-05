using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IBlock
{
    public Rigidbody rigidbody;

    private IConcept _concept; 
    


    public void SetConcept(IConcept concept)
    {
        _concept = concept;
    }

    public IConcept GetConcept()
    {
        return _concept;
    }

    public virtual void ActivatePhysics()
    {
        rigidbody.isKinematic = false;
    }
}