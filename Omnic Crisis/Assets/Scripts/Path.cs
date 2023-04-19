using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    List<Transform> nodeList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform node in transform)
        {
            nodeList.Add(node);
        }
    }

    public Vector3 GetNodePos(int i)
    {
        return nodeList[i].position;
    }

    public int GetMaxNodeNum()
    {
        return nodeList.Count;
    }
}
