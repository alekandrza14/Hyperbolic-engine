using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


[CustomEditor(typeof(Transform))]
public class TransformViewer : Editor
{
    
    
    
    public override void OnInspectorGUI()
    {



        Transform mp = (Transform)target;


        bool Hyperblic = mp.gameObject.GetComponent<Sphere>();
        bool Hyperbliccam = mp.gameObject.GetComponent<Camd>();

        // base.OnInspectorGUI();
        if (!Hyperblic && !Hyperbliccam)
        {


           mp.position = EditorGUILayout.Vector3Field("Poisition", mp.position);

            Vector3 rot = EditorGUILayout.Vector3Field("Rotatation", mp.rotation.eulerAngles);
            mp.rotation = Quaternion.Euler(rot.x,rot.y,rot.z);

            mp.localScale = EditorGUILayout.Vector3Field("Scale", mp.localScale);
        }
        if (Hyperblic)
        {
            Sphere hyperbolicTransform = mp.gameObject.GetComponent<Sphere>();

            Sphere ht = hyperbolicTransform;

            ht.position = EditorGUILayout.Vector4Field("Hyperblic Poisition", ht.position);

            Vector3 rot = EditorGUILayout.Vector3Field("Rotatation", ht.rotation.eulerAngles);
            ht.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);

            ht.ls = EditorGUILayout.Vector3Field("Scale", ht.ls);
            ht.Update();
            ht.edit();
        }
        
        if (Hyperbliccam)
        {
            Camd hyperbolicTransform = mp.gameObject.GetComponent<Camd>();

            Camd ht = hyperbolicTransform;

            ht.position = EditorGUILayout.Vector4Field("Hyperblic Poisition", ht.position);

            Vector3 rot = EditorGUILayout.Vector3Field("Rotatation", ht.rotation.eulerAngles);
            ht.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);

            EditorGUILayout.Vector3Field("Scale (No Work)", Vector3.zero);
            ht.Update();

            ht.edit();
        }
        
    }



}


