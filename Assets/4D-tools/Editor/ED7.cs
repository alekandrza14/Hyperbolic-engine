using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(target4D))]


public class ED7 : Editor
{
    private void OnSceneGUI()
    {
        Camera4D c = Camera4D.Main();
        for (int i = 0; i < FindObjectsOfType<target4D>().Length; i++)
        {
            FindObjectsOfType<target4D>()[i].targetUpdate(c.pos4,-c.transform.position);
        }
        for (int i = 0; i < FindObjectsOfType<tringle4D>().Length; i++)
        {
            FindObjectsOfType<tringle4D>()[i].targetUpdate1(c.pos4, -c.transform.position);
        }
        c.targetUpdate(c.pos4);
    }
}
