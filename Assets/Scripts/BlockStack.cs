using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStack : MonoBehaviour, IBlockStack
{
    public List<GameObject> blockPrefabs;

    private string _grade;

    private List<IBlock> _blocks = new List<IBlock>();


    private Vector3 BlockSize => new Vector3(1, .8f, 3);
    private Vector3 BlockSpacing => new Vector3(.5f, 0, .5f);


    public Transform GetTransform()
    {
        return transform;
    }

    public void SetGrade(string grade)
    {
        _grade = grade;
    }

    public string GetGrade()
    {
        return _grade;
    }

    public void AddBlock(IConcept concept)
    {
        var newBlockObject = Instantiate(blockPrefabs[concept.GetMastery()], transform);

        newBlockObject.transform.localPosition = new Vector3((_blocks.Count % 3 - 1) * (BlockSize.x + BlockSpacing.x) * (_blocks.Count / 3 % 2), _blocks.Count / 3 * BlockSize.y, (_blocks.Count % 3 - 1) * (BlockSize.x + BlockSpacing.x) * (1 - _blocks.Count / 3 % 2));
        newBlockObject.transform.localRotation = Quaternion.Euler(90, 90 * (1 - _blocks.Count / 3 % 2), 0);

        var newBlock = newBlockObject.GetComponent<Block>();
        newBlock.SetConcept(concept);
        _blocks.Add(newBlock);
    }

    public void ActivatePhysicsForStack()
    {
        foreach (var block in _blocks)
        {
            block.ActivatePhysics();
        }
    }
}