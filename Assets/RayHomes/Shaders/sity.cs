using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.TestTools;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]






public class sity : SceneViewFilter
{
    public Vector3 campos; 
    public Vector3 ppos;
    public MeshRenderer m;
    [ImageEffectOpaque]
    void Update()
    {
        campos = Camera.main.transform.position;

        campos += ppos;
        transform.position = Camera.main.transform.position;
        m.material.SetFloat("P1", -campos.x / transform.localScale.x);
        m.material.SetFloat("P2", -campos.y / transform.localScale.y);
        m.material.SetFloat("P3", -campos.z / transform.localScale.z);
#if UNITY_EDITOR
        Vector3 cam = SceneView.lastActiveSceneView.camera.transform.position;
        campos = cam;
        campos += ppos;
        transform.position = cam;
        m.material.SetFloat("P1", -campos.x / transform.localScale.x);
        m.material.SetFloat("P2", -campos.y / transform.localScale.y);
        m.material.SetFloat("P3", -campos.z / transform.localScale.z);
#endif

    }
    

    
}
