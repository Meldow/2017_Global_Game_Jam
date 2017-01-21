using System.Collections;
using UnityEngine.AI;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour {
        //References
        private Animator anim;
        private NavMeshAgent agent;

        //Animations
        private int attackHash;
        private int deadkHash;


        //Navigation
        private GameObject goal;

        //Attack
        private bool canAttack = true;
        [SerializeField]
        private float attackCooldown;
        [SerializeField]
        private float attackRange;

        //Health
        private int hp;
        public int HP {
            get {
                return hp;
            }
            set {
                hp = value;
                if (hp <= 0) Death();
            }
        }

        //General logic
        [SerializeField]
        private EnemyTypes enemyColor;

        //public GameObject health1;
        //public GameObject health2;
        //public GameObject health3;
        //public GameObject health4;

        void Awake() {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
            goal = GameObject.FindWithTag("Player");
        }

        void Start() {
            attackHash = Animator.StringToHash("attack");
            deadkHash = Animator.StringToHash("dead");
            agent.destination = goal.transform.position;
            agent.stoppingDistance = attackRange;
            SetHealth();
            SetHealthColor();
            hp = 1;
            //health1.transform.RotateAroundLocal(axis, 90);
            //health2.transform.RotateAroundLocal(axis, 90);
            //health3.transform.RotateAroundLocal(axis, 90);
            //health4.transform.RotateAroundLocal(axis, 90);
        }

        // Update is called once per frame
        void Update() {
            if (canAttack && CheckRange()) {
                Attack();
                StartCoroutine(AttackCooldown());
            }
            // var wantedPos = Camera.main.WorldToViewportPoint(this.transform.position);
            Vector3 shiftX = new Vector3(1, 0, 0);
            Vector3 shiftY = new Vector3(0, 0, 1);

            //health1.transform.position = (this.transform.position + shiftX);
            //if (!health2.Equals(null)) {
            //    health2.transform.position = (this.transform.position + shiftX + shiftY);
            //}
            //if (!health3.Equals(null)) {
            //    health3.transform.position = (this.transform.position + shiftX + (2 * shiftY));
            //}
            //if (!health4.Equals(null)) {
            //    health4.transform.position = (this.transform.position + shiftX + (3 * shiftY));
            //}

        }

        private void SetHealthColor() {
            //if (enemyColor.Equals(EnemyTypes.Blue)) {
            //    health2.gameObject.GetComponent<Image>().color = Color.blue;
            //    health3.gameObject.GetComponent<Image>().color = Color.blue;
            //    health4.gameObject.GetComponent<Image>().color = Color.blue;
            //}
            //if (enemyColor.Equals(EnemyTypes.Red)) {
            //    health1.gameObject.GetComponent<Image>().color = Color.red;
            //    health2.gameObject.GetComponent<Image>().color = Color.red;
            //    health3.gameObject.GetComponent<Image>().color = Color.red;
            //    health4.gameObject.GetComponent<Image>().color = Color.red;
            //}


        }
        private void SetHealth() {
            if (hp == 1) {
                //health2.gameObject.SetActive(false);
                //health3.gameObject.SetActive(false);
                //health4.gameObject.SetActive(false);
                //Destroy(health2.gameObject);
                //Destroy(health3.gameObject);
                //Destroy(health4.gameObject);
            } else if (hp == 2) {
                //health2.gameObject.SetActive(false);
                //health3.gameObject.SetActive(false);
                //health4.gameObject.SetActive(false);
                //Destroy(health3.gameObject);
                //Destroy(health4.gameObject);
            } else if (hp == 3) {
                //health2.gameObject.SetActive(false);
                //health3.gameObject.SetActive(false);
                //health4.gameObject.SetActive(false);
                //Destroy(health4.gameObject);
            }
        }

        private void Death() {
            anim.SetTrigger(deadkHash);
            agent.Stop();
            Destroy(gameObject, 5);
        }

        private bool CheckRange() {
            return Vector3.Distance(goal.transform.position, this.transform.position) < attackRange;
        }

        private void Attack() {
            canAttack = false;
            anim.SetTrigger(attackHash);
            Debug.Log("attacked");
        }
        IEnumerator AttackCooldown() {
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}