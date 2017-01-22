using Player;
using UnityEngine;
using Util;

namespace Enemy {
    public class TowerManager : Singleton<TowerManager> {
        [SerializeField]
        private GameObject RedTowerIcon;
        [SerializeField]
        private GameObject RedTowerSpawnpoint;
        [SerializeField]
        private GameObject RedTower;
        [SerializeField]
        private GameObject BlueTowerIcon;
        [SerializeField]
        private GameObject BlueTowerSpawnpoint;
        [SerializeField]
        private GameObject BlueTower;
        [SerializeField]
        private GameObject YellowTowerIcon;
        [SerializeField]
        private GameObject YellowTowerSpawnpoint;
        [SerializeField]
        private GameObject YellowTower;
        [SerializeField]
        private GameObject GreenTowerIcon;
        [SerializeField]
        private GameObject GreenTowerSpawnpoint;
        [SerializeField]
        private GameObject GreenTower;

        public void SpawnRedTower() {
            var tower = Instantiate(RedTower);
            tower.transform.position = RedTowerSpawnpoint.transform.position;
            Attack.Instance.CoinCollector -= Attack.Instance.TowerCost;
        }

        public void SpawnBlueTower() {
            var tower = Instantiate(BlueTower);
            tower.transform.position = BlueTowerSpawnpoint.transform.position;
            Attack.Instance.CoinCollector -= Attack.Instance.TowerCost;
        }

        public void SpawnGreenTower() {
            var tower = Instantiate(GreenTower);
            tower.transform.position = GreenTowerSpawnpoint.transform.position;
            Attack.Instance.CoinCollector -= Attack.Instance.TowerCost;
        }

        public void SpawnYellowTower() {
            var tower = Instantiate(YellowTower);
            tower.transform.position = YellowTowerSpawnpoint.transform.position;
            Attack.Instance.CoinCollector -= Attack.Instance.TowerCost;
        }

        public void EnableIcons() {
            RedTowerIcon.SetActive(true);
            GreenTowerIcon.SetActive(true);
            BlueTowerIcon.SetActive(true);
            YellowTowerIcon.SetActive(true);
        }

        public void DisableIcons() {
            RedTowerIcon.SetActive(false);
            GreenTowerIcon.SetActive(false);
            BlueTowerIcon.SetActive(false);
            YellowTowerIcon.SetActive(false);
        }

    }
}
