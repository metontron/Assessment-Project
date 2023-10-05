using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConcept
{
    public int GetID();
    public string GetSubject();
    public string GetGrade();
    public int GetMastery();
    public string GetDomainID();
    public string GetDomain();

    public string GetCluster();
    public string GetStandardID();
    public string GetStandardDescription();
}