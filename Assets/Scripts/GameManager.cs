using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StackBuilder stackBuilder;
    public CameraFollower cameraFollower;

    public int targetStack;

    public TMP_Text stackName;

    public Transform blockInformationPanel;
    public TMP_Text blockInformationGradeLevel;
    public TMP_Text blockInformationDomain;
    public TMP_Text blockInformationCluster;
    public TMP_Text blockInformationStandardID;
    public TMP_Text blockInformationStandardDescription;

    void Start()
    {
        TextAsset jsonTextAsset = Resources.Load<TextAsset>("stack");

        List<IConcept> concepts = APIManager.GetConceptData(jsonTextAsset.text);

        stackBuilder.BuildStacks(concepts);

        cameraFollower.target = stackBuilder.stacks[targetStack].GetTransform();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetStack = targetStack > 0 ? targetStack - 1 : stackBuilder.stacks.Count - 1;
            ChangeSelectedStack();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetStack = targetStack < stackBuilder.stacks.Count - 1 ? targetStack + 1 : 0;
            ChangeSelectedStack();
        }

        RaycastHit raycastHit;
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
        {
            if (raycastHit.transform.TryGetComponent<Block>(out Block selectedBlock))
            {
                var concept = selectedBlock.GetConcept();
                blockInformationPanel.gameObject.SetActive(true);
                blockInformationGradeLevel.text = "Grade: " + concept.GetGrade();
                blockInformationDomain.text = "Domain: " + concept.GetDomain();
                blockInformationCluster.text = "Cluster: " + concept.GetCluster();
                blockInformationStandardID.text = "Standard ID: " + concept.GetStandardID();
                blockInformationStandardDescription.text = "Standard Description: " + concept.GetStandardDescription();
            }
        }
    }

    public void ChangeSelectedStack()
    {
        cameraFollower.target = stackBuilder.stacks[targetStack].GetTransform();
        stackName.text = stackBuilder.stacks[targetStack].GetGrade();
    }

    public void TestStacks()
    {
        stackBuilder.stacks[targetStack].ActivatePhysicsForStack();
    }
}