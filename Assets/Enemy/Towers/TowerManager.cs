using UnityEngine;
using Util;

namespace Enemy {
    public class TowerManager : Singleton<TowerManager> {
        [SerializeField]
        private GameObject RedTowerSpawnpoint;
        [SerializeField]
        private GameObject RedTower;
        [SerializeField]
        private GameObject BlueTowerSpawnpoint;
        [SerializeField]
        private GameObject BlueTower;
        [SerializeField]
        private GameObject YellowTowerSpawnpoint;
        [SerializeField]
        private GameObject YellowTower;
        [SerializeField]
        private GameObject GreenTowerSpawnpoint;
        [SerializeField]
        private GameObject GreenTower;

        public void SpawnRedTower() {
            var tower = Instantiate(RedTower);
            tower.transform.position = RedTowerSpawnpoint.transform.position;
        }

        public void SpawnBlueTower() {
            var tower = Instantiate(BlueTower);
            tower.transform.position = BlueTowerSpawnpoint.transform.position;
        }

        public void SpawnGreenTower() {
            var tower = Instantiate(GreenTower);
            tower.transform.position = GreenTowerSpawnpoint.transform.position;
        }

        public void SpawnYellowTower() {
            var tower = Instantiate(YellowTower);
            tower.transform.position = YellowTowerSpawnpoint.transform.position;
        }

    }
}
