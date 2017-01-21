using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Spawner;

namespace Spawner{
	[CustomEditor(typeof(SpawnerManager))]
	public class SpawnerEditor : Editor {
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			var script = (SpawnerManager)target;

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Spawn red enemy")) {
				script.spawnRedEnemy ();
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Spawn blue enemy")) {
				script.spawnBlueEnemy ();
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Spawn green enemy")) {
				script.spawnGreenEnemy ();
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Spawn yellow enemy")) {
				script.spawnYellowEnemy ();
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Spawn random enemy")) {
				script.spawnRandomColor ();
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Spawn enemies")) {
				script.spawnEnemiesWithColorAndNumber (SpawnerManager.ENEMY_COLORS.BLUE, 4);
			}
			GUILayout.EndHorizontal();
		}
	}
}
