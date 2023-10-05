using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockStack
{
    public Transform GetTransform();
    public void SetGrade(string grade);
    public string GetGrade();

    public void AddBlock(IConcept concept);

    public void ActivatePhysicsForStack();
}