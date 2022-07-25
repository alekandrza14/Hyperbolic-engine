using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class target4D : MonoBehaviour
{
    public float pos4;
    public float scale4;
    public Vector3 startpos;
    public MeshRenderer mr;
    public SphereCollider mc;
    public Material notradius;
    public Material isradius;
    private void Awake()
    {
        
    }
    public void targetUpdate(float pos42, Vector3 v3)
    {
        transform.position = startpos * (pos4 - pos42);
        transform.position += v3;
        mr.material = isradius;
        mc.enabled = true;
        if ((scale4 - pos4 - pos42) / scale4 < -scale4 || (scale4 - pos4 - pos42) / scale4 > scale4)
        {
            mc.enabled = false;
            mr.material = notradius;
        }
    }
    public void targetresset(Vector3 v3)
    {
        startpos = v3;
    }
}
