using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DaemonsGate.Waves;

public class ResolveWavePositionsWindow : EditorWindow
{
    Wave wave;
    Transform[] positions;
    SerializedObject so;
    SerializedProperty propWaveSpawnPoitions;
    [MenuItem("DaemonsGate/Resolve wave positions")]
    public static void Open()
    {
        ResolveWavePositionsWindow window = GetWindow<ResolveWavePositionsWindow>("Resolve wave positions");
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    /// <summary>
    /// Similar to Start()
    /// </summary>
    private void OnEnable()
    {
        so = new SerializedObject(wave);
        propWaveSpawnPoitions = so.FindProperty("spawnPositions");
    }

    /// <summary>
    /// Similar to Update
    /// </summary>
    private void OnGUI()
    {

        wave = (Wave)EditorGUILayout.ObjectField(wave, typeof(ScriptableObject), true);
        if (GUILayout.Button("Resolve!"))
        {
            wave.spawnPositions = new Vector3[Selection.count];
            for (int i = 0; i < Selection.count; i++)
            {
                wave.spawnPositions[i] = Selection.gameObjects[i].transform.position;
            }
        } 
    }
}
