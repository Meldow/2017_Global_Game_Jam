using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy {

    public class Enemy : MonoBehaviour {
        public int hp = 1;
        public GameObject goal;
        public EnemyTypes enemyColor;
        private bool canAttack = true;
        [SerializeField]
        private float attackCooldown;
        [SerializeField]
        private float attackRange;
        public GameObject health1;
        public GameObject health2;
        public GameObject health3;
        public GameObject health4;
        NavMeshAgent agent; 

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.destination = goal.transform.position;
            SetHealth();
            SetHealthColor();
            Vector3 axis = new Vector3(1, 0, 0);
            //health1.transform.RotateAroundLocal(axis, 90);
            //health2.transform.RotateAroundLocal(axis, 90);
            //health3.transform.RotateAroundLocal(axis, 90);
            //health4.transform.RotateAroundLocal(axis, 90);
        }

        // Update is called once per frame
        void Update() {
            agent.updateRotation = false;
            if (canAttack && CheckRange()) {
                Attack();
                StartCoroutine(AttackCooldown());
               
            }
            // var wantedPos = Camera.main.WorldToViewportPoint(this.transform.position);
            Vector3 shiftX = new Vector3(1, 0, 0);
            Vector3 shiftY = new Vector3(0, 0, 1);
            
            health1.transform.position = (this.transform.position + shiftX);
            if (!health2.Equals(null)) {
                health2.transform.position = (this.transform.position + shiftX + shiftY);
            }
            if (!health3.Equals(null)) {
                health3.transform.position = (this.transform.position + shiftX + (2 * shiftY));
            }
            if (!health4.Equals(null)) {
                health4.transform.position = (this.transform.position + shiftX + (3 * shiftY));
            }

        }

        private void SetHealthColor() {
            if (enemyColor.Equals(EnemyTypes.Blue)) {
                health2.gameObject.GetComponent<Image>().color = Color.blue;
                health3.gameObject.GetComponent<Image>().color = Color.blue;
                health4.gameObject.GetComponent<Image>().color = Color.blue;
            }
            if (enemyColor.Equals(EnemyTypes.Red)) {
                health1.gameObject.GetComponent<Image>().color = Color.red;
                health2.gameObject.GetComponent<Image>().color = Color.red;
                health3.gameObject.GetComponent<Image>().color = Color.red;
                health4.gameObject.GetComponent<Image>().color = Color.red;
            }


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
            
            if (Vector3.Distance(goal.transform.position, this.transform.position) < attackRange) {
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