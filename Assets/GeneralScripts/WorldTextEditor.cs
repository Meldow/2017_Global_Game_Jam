#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UI {
    [CustomEditor(typeof(WorldText))]
    public class WorldTextEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            var script = (WorldText)target;

            if (GUILayout.Button("Need Fire Extinguisher")) {
                script.SetText("I need a fire extinguisher...");
            }
            if (GUILayout.Button("Use fire extinguisher")) {
                script.SetText("I can use a fire extinguisher.. \nPress F");
            }
            if (GUILayout.Button("Welcome")) {
                script.SetText("My car just broke down... \nI should find some fuel and\n a wrench to get it going");
            }
            if (GUILayout.Button("Getting late")) {
                script.SetText("It sure is getting late..");
            }
        }
    }
}
#endif