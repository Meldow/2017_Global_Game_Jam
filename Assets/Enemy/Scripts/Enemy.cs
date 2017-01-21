using System.Collections;
using UnityEngine.AI;
using UnityEngine;

namespace Enemy {

    public class Enemy : MonoBehaviour {
        public int hp = 1;
        public Transform goal;
        public EnemyTypes enemyColor;
        private bool canAttack = true;
        [SerializeField]
        private float attackCooldown;
        [SerializeField]
        private float attackRange;
        public Transform health1;
        public Transform health2;
        public Transform health3;
        public Transform health4;
        void Start() {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
            SetHealth();
        }

        // Update is called once per frame
        void Update() {
            if (canAttack && CheckRange()) {
                Attack();
                StartCoroutine(AttackCooldown());
               
            }
            // var wantedPos = Camera.main.WorldToViewportPoint(this.transform.position);
            Vector3 shiftX = new Vector3(1, 0, 0);
            Vector3 shiftY = new Vector3(0, 2, 0);
            health1.transform.position = (this.transform.position + shiftX);
            health2.transform.position = (this.transform.position + shiftX + shiftY) ;
            health3.transform.position = (this.transform.position + shiftX + (2*shiftY));
            health4.transform.position = (this.transform.position + shiftX + (3*shiftY));

        }
        private void SetHealth() {
            if (hp == 1) {
                //health2.gameObject.SetActive(false);
                //health3.gameObject.SetActive(false);
                //health4.gameObject.SetActive(false);
                Destroy(health2.gameObject);
                Destroy(health3.gameObject);
                Destroy(health4.gameObject);
            }
            else if (hp == 2) {
                //health2.gameObject.SetActive(false);
                //health3.gameObject.SetActive(false);
                //health4.gameObject.SetActive(false);
                Destroy(health3.gameObject);
                Destroy(health4.gameObject);
            } else if (hp == 3) {
                //health2.gameObject.SetActive(false);
                //health3.gameObject.SetActive(false);
                //health4.gameObject.SetActive(false);
                Destroy(health4.gameObject);
            }
        }
        private void ReceiveDamage() {
            //verificar cor de ataque
            hp--;
            if (hp == 0) {
                Death();
            }
        }

        private void Death() {
            Destroy(this);
        }

        private bool CheckRange() {
            
            if (Vector3.Distance(goal.position, this.transform.position) < attackRange) {
                return true;
            } else
                return false;
        }

        private void Attack() {
            canAttack = false;
            Debug.Log("attacked");
        }
        IEnumerator AttackCooldown() {
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}