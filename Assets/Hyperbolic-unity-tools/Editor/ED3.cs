using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Create_4D
{
    static int mainversion = 0; static int neoversion = 1; static int version = 0;
    [MenuItem("GameObject/4D Object/Hyperbolic geometry/Point")]
    public static void Create()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("Point")
        {

        };
        g.AddComponent<Sphere>();
    }
    [MenuItem("GameObject/4D Object/Hyperbolic geometry/Cube")]
    public static void CreateCube()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("Cube")
        {

        };
        if (Hyperbolicmovetool.mainEdit != null) { g.AddComponent<Sphere>().p2 = Hyperbolicmovetool.mainEdit.p2; g.GetComponent<Sphere>().v1 = Hyperbolicmovetool.mainEdit.v1; } else g.AddComponent<Sphere>();

        g.AddComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("Cube");
        g.AddComponent<BoxCollider>();
       g.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
    }
    [MenuItem("GameObject/4D Object/Hyperbolic geometry/Sphere")]
    public static void CreateSphere()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("Sphere")
        {

        };
        if (Hyperbolicmovetool.mainEdit != null) {g.AddComponent<Sphere>().p2 = Hyperbolicmovetool.mainEdit.p2; g.GetComponent<Sphere>().v1 = Hyperbolicmovetool.mainEdit.v1; } else g.AddComponent<Sphere>();
        g.AddComponent<SphereCollider>();
        g.AddComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("Sphere");
        g.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
    }
}