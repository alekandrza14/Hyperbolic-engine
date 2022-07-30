using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApsoluteColiderPline : MonoBehaviour
{
    public Transform obj;
    void Update()
    {
        if (obj.position.y < transform.position.y)
        {


            obj.position = new Vector3(obj.position.x, transform.position.y, obj.position.z);
        }
    }
}
