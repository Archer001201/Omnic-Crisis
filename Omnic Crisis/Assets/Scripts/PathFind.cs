using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    public Path path;
    int curPathNodeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (curPathNodeIndex >= path.GetMaxNodeNum())
        {
            return;
        }
        Vector3 curNodePos = path.GetNodePos(curPathNodeIndex);
        float dis = Vector3.Distance(curNodePos, transform.position);
        if (dis < 0.1f) curPathNodeIndex++;

        Vector3 dir = (curNodePos - transform.position).normalized;
        transform.position += dir * 6 * Time.deltaTime;
    }
}
