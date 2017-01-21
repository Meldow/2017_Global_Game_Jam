using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Enemy;

namespace Enemy {
    [CustomEditor(typeof(LifeColor))]
    public class LifeColorEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            var script = (LifeColor)target;

            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Set Red")) {
                script.Color = Color.red;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Set Green")) {
                script.Color = Color.green;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Set Blue")) {
                script.Color = Color.blue;
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Set Yellow")) {
                script.Color = Color.yellow;
            }
            GUILayout.EndHorizontal();
        }
    }
}