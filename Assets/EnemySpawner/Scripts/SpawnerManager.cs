using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawner;

namespace Spawner{
	public class SpawnerManager : MonoBehaviour {
		private  GameObject[] spawnPoints;
		public GameObject redEnemy;
		public GameObject greenEnemy;
		public GameObject blueEnemy;
		public GameObject yellowEnemy;
		public enum ENEMY_COLORS {RED,GREEN,BLUE,YELLOW}; 
		// Use this for initialization
		void Start () {
			if(spawnPoints==null)
				spawnPoints = GameObject.FindGameObjectsWithTag ("Spawn");
		}

		public void spawnRedEnemy(){
			GameObject spawnPoint = spawnPoints[(Random.Range(0,spawnPoints.Length))];
			Instantiate (redEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
		}
			
		public void spawnBlueEnemy(){
			GameObject spawnPoint = spawnPoints[(Random.Range(0,spawnPoints.Length))];
			Instantiate (blueEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
		}
			
		public void spawnGreenEnemy(){
			GameObject spawnPoint = spawnPoints[(Random.Range(0,spawnPoints.Length))];
			Instantiate (greenEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
		}
			
		public void spawnYellowEnemy(){
			GameObject spawnPoint = spawnPoints[(Random.Range(0,spawnPoints.Length))];
			Instantiate (yellowEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
		}

		public void spawnRandomColor(){
			GameObject spawnPoint = spawnPoints[(Random.Range(0,spawnPoints.Length))];
			int colorIndex = Random.Range (0, 3);
			switch (colorIndex) {
			case 0:
				Instantiate (redEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
				break;
			case 1:
				Instantiate (greenEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
				break;
			case 2:
				Instantiate (blueEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
				break;
			case 3:
				Instantiate (yellowEnemy, spawnPoint.transform.position, Quaternion.Euler(90,0,0));
				break;
			}
		}

		public void spawnEnemiesWithColorAndNumber(ENEMY_COLORS color, int numberOfEnemies){
			switch (color) {
			case ENEMY_COLORS.BLUE:
				GameObject spawnPoint = spawnPoints[(Random.Range(0,spawnPoints.Length))];
				for (int i = 0; i < numberOfEnemies; i++) {
					Vector3 newPosition = new Vector3(spawnPoint.transform.position.x + (i*2),spawnPoint.transform.position.y,spawnPoint.transform.position.z);
					Instantiate (blueEnemy, newPosition, Quaternion.Euler(90,0,0));
				}
				break;
			case ENEMY_COLORS.GREEN:
				for (int i = 0; i < numberOfEnemies; i++) {
					spawnGreenEnemy ();
				}
				break;

			case ENEMY_COLORS.RED:
				for (int i = 0; i < numberOfEnemies; i++) {
					spawnRedEnemy ();
				}
				break;
			case ENEMY_COLORS.YELLOW:
				for (int i = 0; i < numberOfEnemies; i++) {
					spawnYellowEnemy ();
				}
				break;
			}
		}
	}
}