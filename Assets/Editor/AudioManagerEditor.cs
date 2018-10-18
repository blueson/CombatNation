using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioManagerEditor : EditorWindow {

    [MenuItem("Manager/AudioManager")]
    static void CreateWindow(){
        var window = GetWindow<AudioManagerEditor>();
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.TextField("输入名称");
    }
}
