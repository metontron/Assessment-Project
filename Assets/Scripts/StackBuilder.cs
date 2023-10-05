using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackBuilder : MonoBehaviour
{
    public GameObject stackParentPrefab;

    public List<IBlockStack> stacks = new List<IBlockStack>();

    public void BuildStacks(List<IConcept> concepts)
    {
        concepts.OrderBy(x => x.GetGrade()).ThenBy(x => x.GetDomain()).ThenBy(x => x.GetCluster()).ThenBy(x => x.GetStandardID());

        foreach (var concept in concepts)
        {
            Debug.Log(concept.GetGrade());
            if (stacks.Count == 0 || !string.Equals(stacks[^1].GetGrade(), concept.GetGrade()))
            {
                var newStack = Instantiate(stackParentPrefab, Vector3.left * 15f * stacks.Count, Quaternion.identity, transform).GetComponent<BlockStack>();
                newStack.SetGrade(concept.GetGrade());
                newStack.AddBlock(concept);
                stacks.Add(newStack);
            }
            else
            {
                stacks[^1].AddBlock(concept);
            }
        }
    }
}