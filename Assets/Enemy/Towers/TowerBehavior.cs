using Enemy;
using Player;
using UnityEngine;

namespace Turrets {
    public class TowerBehavior : MonoBehaviour {
        [SerializeField]
        private ParticleSystem particleSystem;
        [SerializeField]
        private AttackType attackType;
        [SerializeField]
        public int numberAttacks;

        void Awake() {
            TowerManager.Instance.ToggleIcon(attackType, false);
        }

        public void PulseAttack() {
            var ps = Instantiate(particleSystem);
            ps.GetComponent<ParticleStrenght>().SetStrength(AttackStrength.Normal);
            ps.GetComponent<Projectile>().attackEnemy = new AttackEnemy() { damage = 2, power = 30, attackType = attackType };

            numberAttacks -= 1;
            if (numberAttacks <= 0) {
                TowerManager.Instance.ToggleIcon(attackType, true);
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
