using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIManager
{
    public static List<IConcept> GetConceptData(string json)
    {
        Debug.Log(json);

        ConceptsRootData conceptData = JsonUtility.FromJson<ConceptsRootData>(json);


        if (conceptData == null || conceptData.concepts.Count == 0)
        {
            Debug.LogError("JSON data is empty or couldn't be deserialized.");
            return null;
        }

        List<IConcept> concepts = new List<IConcept>();

        foreach (var conceptJsonData in conceptData.concepts)
        {
            concepts.Add(new Concept(conceptJsonData.id, conceptJsonData.subject, conceptJsonData.grade, conceptJsonData.mastery, conceptJsonData.domainid, conceptJsonData.domain, conceptJsonData.cluster, conceptJsonData.standardid, conceptJsonData.standarddescription));
        }


        return concepts;
    }
}

public class ConceptsRootData
{
    public List<ConceptJsonData> concepts;
}

[System.Serializable]
public class ConceptJsonData
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}