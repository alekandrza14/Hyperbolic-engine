using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class poligondebug
{
    public static bool enable;
}


public class tringle4D : MonoBehaviour
{
    public float pos4; public float pos41; public float pos43;
    public Vector3 startpos; public Vector3 startpos1; public Vector3 startpos2;
    public float scale4;
    public MeshFilter mf; 
    public MeshRenderer mr;
    public MeshCollider mc;
    public bool v;
    public Material notradius;
    public Material isradius;
    Vector3 v31; Vector3 v32; Vector3 v33;
    public Material isradiusdebug;
    public static bool isEditor = true;
    private void Awake()
    {
        
    }
    private void Start()
    {
        isEditor = true;
    }
    public void targetUpdate(float pos42, Vector3 v3)
    {
        v31 = startpos * (pos4 - pos42);
        v31 += v3;
        v32 = startpos1 * (pos41 - pos42);
        v32 += v3;
        v33 = startpos2 * (pos43 - pos42);
        v33 += v3;


        Createmath(v31, v32, v33, pos42);


    }
    public void targetUpdate1(float pos42, Vector3 v3)
    {
        v31 = startpos * (pos4 - pos42);
        v31 += v3;
        v32 = startpos1 * (pos41 - pos42);
        v32 += v3;
        v33 = startpos2 * (pos43 - pos42);
        v33 += v3;


        Createmath1(v31, v32, v33, pos42);


    }
    public void targetresset(Vector3 v3)
    {
        startpos = v3;
    }
    public void Createmath(Vector3 v1, Vector3 v2, Vector3 v3, float f1)
    {


        var m = new Mesh();
        m.Clear();
        Vector3[] verticles = new Vector3[3]
       {
            v1,v2,v3
       }; Vector3[] n = new Vector3[3]
       {
            Vector3.up,Vector3.up,Vector3.up
       }; Vector2[] uv = new Vector2[3]
       {
          new Vector2(0,1) , new Vector2(0,0), new Vector2(1,0)
       }; int[] tranglse = new int[3]
       {
            0,1,2
       };
        if (v)
        {
            tranglse = new int[3]
       {
            0,2,1
       };
        }
        m.SetVertices(verticles);
        m.triangles = tranglse;
        m.uv = uv;
        m.normals = n;
        mf.sharedMesh = m;
        mc.sharedMesh = m; if (!poligondebug.enable)
        {

            mr.material = isradius;
        }
        if (poligondebug.enable)
        {

            mr.material = isradiusdebug;
        }
        mc.enabled = true;






        //_EmissionColor

        if ((scale4 - pos4 - f1) / scale4 < -scale4 || (scale4 - pos4 - f1) / scale4 > scale4)
        {
            mc.enabled = false;
            mr.material = notradius;
        }
        if ((scale4 - pos41 - f1) / scale4 < -scale4 || (scale4 - pos41 - f1) / scale4 > scale4)
        {
            mc.enabled = false;
            mr.material = notradius;
        }
        if ((scale4 - pos43 - f1)/ scale4 < -scale4 || (scale4 - pos43 - f1) / scale4 > scale4)
        {
            mc.enabled = false;
            mr.material = notradius;
        }


    }
    public void Createmath1(Vector3 v1, Vector3 v2, Vector3 v3, float f1)
    {


        var m = new Mesh();
        m.Clear();
        Vector3[] verticles = new Vector3[3]
       {
            v1,v2,v3
       }; Vector3[] n = new Vector3[3]
       {
            Vector3.up,Vector3.up,Vector3.up
       }; Vector2[] uv = new Vector2[3]
       {
          new Vector2(0,1) , new Vector2(0,0), new Vector2(1,0)
       }; int[] tranglse = new int[3]
       {
            0,1,2
       };
        if (v)
        {
            tranglse = new int[3]
       {
            0,2,1
       };
        }
        m.SetVertices(verticles);
        m.triangles = tranglse;
        m.uv = uv;
        m.normals = n;
        mf.sharedMesh = m;
        mc.sharedMesh = m; if (!poligondebug.enable)
        {

            mr.material = isradius;
        }
        if (poligondebug.enable)
        {

            mr.material =isradiusdebug;
        }
        mc.enabled = true;






        //_EmissionColor

       

            if ((scale4 - pos4 - f1) / scale4 < -scale4 || (scale4 - pos4 - f1) / scale4 > scale4)
            {
                mc.enabled = false;
                mr.material = notradius;
            }
            if ((scale4 - pos41 - f1) / scale4 < -scale4 || (scale4 - pos41 - f1) / scale4 > scale4)
            {
                mc.enabled = false;
                mr.material = notradius;
            }
            if ((scale4 - pos43 - f1) / scale4 < -scale4 || (scale4 - pos43 - f1) / scale4 > scale4)
            {
                mc.enabled = false;
                mr.material = notradius;
            }
        
        


    }
}
