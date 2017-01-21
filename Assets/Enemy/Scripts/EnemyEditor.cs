#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Enemy {
    [CustomEditor(typeof(Enemy))]
    [CanEditMultipleObjects]
    public class EnemyEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            var script = (Enemy)target;

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Take 1 DMG")) {
                script.HP--;
            }
            GUILayout.EndHorizontal();
        }
    }
}
#endif