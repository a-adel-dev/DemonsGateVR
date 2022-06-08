using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DaemonsGate.Waves;

[CanEditMultipleObjects]
[CustomEditor(typeof(Wave))]
public class ResolveWavePositionsEditor : Editor
{

    /*
    SerializedObject so;
    SerializedProperty propWaveID;
    SerializedProperty propWaveDuration;
    SerializedProperty propWaveEnemies;
    SerializedProperty propWaveSpawnPoitions;

    private void OnEnable()
    {
        so = serializedObject;
        propWaveID = so.FindProperty("waveId");
        propWaveDuration = so.FindProperty("waveDuration");
        propWaveEnemies = so.FindProperty("enemies");
        propWaveSpawnPoitions = so.FindProperty("spawnPositions");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        so.Update();
        EditorGUILayout.PropertyField(propWaveID);
        EditorGUILayout.PropertyField(propWaveDuration);
        EditorGUILayout.PropertyField(propWaveEnemies);
        //EditorGUILayout.PropertyField(propWaveSpawnPoitions);
        so.ApplyModifiedProperties();
    }
    */
}
