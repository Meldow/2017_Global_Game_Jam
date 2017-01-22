using System;
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
        public bool canSpawnRed = true;

        [SerializeField]
        private GameObject BlueTowerIcon;
        [SerializeField]
        private GameObject BlueTowerSpawnpoint;
        [SerializeField]
        private GameObject BlueTower;
        public bool canSpawnBlue = true;

        [SerializeField]
        private GameObject YellowTowerIcon;
        [SerializeField]
        private GameObject YellowTowerSpawnpoint;
        [SerializeField]
        private GameObject YellowTower;
        public bool canSpawnYellow = true;

        [SerializeField]
        private GameObject GreenTowerIcon;
        [SerializeField]
        private GameObject GreenTowerSpawnpoint;
        [SerializeField]
        private GameObject GreenTower;
        public bool canSpawnGreen = true;

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
            if (canSpawnRed) RedTowerIcon.SetActive(true);
            if (canSpawnGreen) GreenTowerIcon.SetActive(true);
            if (canSpawnBlue) BlueTowerIcon.SetActive(true);
            if (canSpawnYellow) YellowTowerIcon.SetActive(true);
        }

        public void DisableIcons() {
            RedTowerIcon.SetActive(false);
            GreenTowerIcon.SetActive(false);
            BlueTowerIcon.SetActive(false);
            YellowTowerIcon.SetActive(false);
        }

        public void ToggleIcon(AttackType attackType, bool state) {
            switch (attackType) {
                case AttackType.Red:
                    RedTowerIcon.SetActive(state);
                    canSpawnRed = state;
                    break;
                case AttackType.Blue:
                    BlueTowerIcon.SetActive(state);
                    canSpawnBlue = state;
                    break;
                case AttackType.Green:
                    GreenTowerIcon.SetActive(state);
                    canSpawnGreen = state;
                    break;
                case AttackType.Yellow:
                    YellowTowerIcon.SetActive(state);
                    canSpawnYellow = state;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("attackType", attackType, null);
            }
        }
    }
}
