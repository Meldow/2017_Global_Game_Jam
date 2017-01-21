using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawner;

namespace Spawner {
    public class SpawnerManager : MonoBehaviour {
        [SerializeField]
        private GameObject[] spawnPoints;
        public GameObject redEnemy;
        public GameObject greenEnemy;
        public GameObject blueEnemy;
        public GameObject yellowEnemy;
        public enum ENEMY_COLORS { RED = 0, GREEN = 1, BLUE = 2, YELLOW = 3 };

        public float startWait;
        public float spawnWait;

        private int level = 0;

        // Use this for initialization
        void Start() {
            //if(spawnPoints==null)
            //	spawnPoints = GameObject.FindGameObjectsWithTag ("Spawn");
            StartCoroutine(SpawnWave());
        }

        IEnumerator SpawnWave() {
            yield return new WaitForSeconds(startWait);
            while (true) {
                level++;
				switch (level) {
				case 1:
					spawnRedEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					break;
				case 2:
					spawnRedEnemy ();
					spawnRedEnemy ();
					spawnGreenEnemy ();
					break;
				case 3:
					spawnGreenEnemy ();
					spawnGreenEnemy ();
					spawnRedEnemy ();
					break;
				case 4:
					spawnYellowEnemy ();
					spawnYellowEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					break;
				case 5:
					spawnBlueEnemy ();
					spawnGreenEnemy ();
					spawnYellowEnemy ();
					spawnBlueEnemy ();
					break;
				case 6:
					spawnGreenEnemy ();
					spawnGreenEnemy ();
					spawnBlueEnemy ();
					spawnBlueEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					break;
				case 7:
					spawnGreenEnemy ();
					spawnGreenEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					spawnYellowEnemy ();
					spawnYellowEnemy ();
					spawnYellowEnemy ();
					break;
				case 8:
					spawnGreenEnemy ();
					spawnBlueEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					break;
				case 9:
					spawnGreenEnemy ();
					spawnGreenEnemy ();
					spawnGreenEnemy ();
					spawnBlueEnemy ();
					spawnBlueEnemy ();
					spawnYellowEnemy ();
					break;
				case 10:
					spawnGreenEnemy ();
					spawnBlueEnemy ();
					spawnYellowEnemy ();
					spawnRedEnemy ();
					spawnRedEnemy ();
					break;
				default:
					for (int i = 0; i < Random.Range(level-4, level); i++) {
						spawnRandomColor();
						/*if (level > 10 && (Random.Range(0, 5) == 0)) {
							spawnEnemiesWithColorAndNumber(parserEnemyColors(Random.Range(1, 3)), Random.Range(2,4));
						}
						*/
					}
					break;

				}

                yield return new WaitForSeconds(spawnWait);
            }
        }

        private ENEMY_COLORS parserEnemyColors(int code) {
            switch (code) {
                case 0:
                    return ENEMY_COLORS.RED;
                case 1:
                    return ENEMY_COLORS.GREEN;
                case 2:
                    return ENEMY_COLORS.BLUE;
                case 3:
                    return ENEMY_COLORS.YELLOW;
            }

            return ENEMY_COLORS.BLUE;

        }

        public void spawnRedEnemy() {
            GameObject spawnPoint = spawnPoints[(Random.Range(0, spawnPoints.Length))];
            Instantiate(redEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
        }

        public void spawnBlueEnemy() {
            GameObject spawnPoint = spawnPoints[(Random.Range(0, spawnPoints.Length))];
            Instantiate(blueEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
        }

        public void spawnGreenEnemy() {
            GameObject spawnPoint = spawnPoints[(Random.Range(0, spawnPoints.Length))];
            Instantiate(greenEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
        }

        public void spawnYellowEnemy() {
            GameObject spawnPoint = spawnPoints[(Random.Range(0, spawnPoints.Length))];
            Instantiate(yellowEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
        }

        public void spawnRandomColor() {
            GameObject spawnPoint = spawnPoints[(Random.Range(0, spawnPoints.Length))];
            int colorIndex = Random.Range(0, 3);
            switch (colorIndex) {
                case 0:
                    Instantiate(redEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
                    break;
                case 1:
                    Instantiate(greenEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
                    break;
                case 2:
                    Instantiate(blueEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
                    break;
                case 3:
                    Instantiate(yellowEnemy, spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
                    break;
            }
        }

        public void spawnEnemiesWithColorAndNumber(ENEMY_COLORS color, int numberOfEnemies) {
            GameObject spawnPoint = spawnPoints[(Random.Range(0, spawnPoints.Length))];
            switch (color) {
                case ENEMY_COLORS.BLUE:
                    for (int i = 0; i < numberOfEnemies; i++) {
                        Vector3 newPosition = new Vector3(spawnPoint.transform.position.x + (i * 2), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                        Instantiate(blueEnemy, newPosition, Quaternion.Euler(90, 0, 0));
                    }
                    break;
                case ENEMY_COLORS.GREEN:
                    for (int i = 0; i < numberOfEnemies; i++) {
                        Vector3 newPosition = new Vector3(spawnPoint.transform.position.x + (i * 2), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                        Instantiate(greenEnemy, newPosition, Quaternion.Euler(90, 0, 0));
                    }
                    break;

                case ENEMY_COLORS.RED:
                    for (int i = 0; i < numberOfEnemies; i++) {
                        Vector3 newPosition = new Vector3(spawnPoint.transform.position.x + (i * 2), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                        Instantiate(redEnemy, newPosition, Quaternion.Euler(90, 0, 0));
                    }
                    break;
                case ENEMY_COLORS.YELLOW:
                    for (int i = 0; i < numberOfEnemies; i++) {
                        Vector3 newPosition = new Vector3(spawnPoint.transform.position.x + (i * 2), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                        Instantiate(yellowEnemy, newPosition, Quaternion.Euler(90, 0, 0));
                    }
                    break;
            }
        }
    }
}