using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;

[CustomEditor(typeof(WindowManager))]
public class WindowManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var windowMgr = target as WindowManager;

        if (GUILayout.Button("Generate Window Enums"))
        {
            //Debug.Log("Click");
            var sb = new StringBuilder();
            sb.Append("public enum Windows\n{\n\tNone = -1,\n");
            foreach (var window in windowMgr.windows)
            {
                sb.Append($"\t{window.name},\n");
            }
            sb.Append("}\n");

            var path = EditorUtility.SaveFilePanel(
            "Save The Window Enums", Application.dataPath, "Windows.cs", "cs");

            using (var fs = new FileStream(path, FileMode.Create))
            using (var writer = new StreamWriter(fs))
            {
                writer.Write(sb.ToString());
            }

            AssetDatabase.Refresh();
        }
        

    }
    

}
