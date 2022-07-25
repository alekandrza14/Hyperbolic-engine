using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(tringle4D))]
public class ED8 : EditorWindow {
    public static bool debug;
    [MenuItem("Window/ed8")]
    
    static void Init()
    {

        // Get existing open window or if none, make a new one:
        ED8 window = (ED8)EditorWindow.GetWindow(typeof(ED8));
        window.Show();
    }
    private void OnGUI()
    {
      debug =  EditorGUILayout.Toggle("debug", debug);
        poligondebug.enable = debug;
       
    }
}
