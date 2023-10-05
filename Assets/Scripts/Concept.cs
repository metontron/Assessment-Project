using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept : IConcept
{
    private int _id;
    private string _subject;
    private string _grade;
    private int _mastery;
    private string _domainID;
    private string _domain;
    private string _cluster;
    private string _standardID;
    private string _standardDescription;

    public Concept(int id, string subject, string grade, int mastery, string domainID, string domain, string cluster, string standardID, string standardDescription)
    {
        _id = id;
        _subject = subject;
        _grade = grade;
        _mastery = mastery;
        _domainID = domainID;
        _domain = domain;
        _cluster = cluster;
        _standardID = standardID;
        _standardDescription = standardDescription;
    }

    public int GetID()
    {
        return _id;
    }

    public string GetSubject()
    {
        return _subject;
    }

    public string GetGrade()
    {
        return _grade;
    }

    public int GetMastery()
    {
        return _mastery;
    }

    public string GetDomainID()
    {
        return _domainID;
    }

    public string GetDomain()
    {
        return _domain;
    }

    public string GetCluster()
    {
        return _cluster;
    }

    public string GetStandardID()
    {
        return _standardID;
    }

    public string GetStandardDescription()
    {
        return _standardDescription;
    }
}