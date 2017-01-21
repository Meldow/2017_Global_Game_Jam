using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine.AI;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour {
        //References
        private List<Animator> animLst;
        private NavMeshAgent agent;
        private Rigidbody rigid;

		//Coins
		public GameObject coin;

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
        private EnemyTypes enemyType;

        void Awake() {
            agent = GetComponent<NavMeshAgent>();
            animLst = GetComponentsInChildren<Animator>().ToList();
            rigid = GetComponentInChildren<Rigidbody>();
            goal = GameObject.FindWithTag("Player");
        }

        void Start() {
            attackHash = Animator.StringToHash("attack");
            deadkHash = Animator.StringToHash("dead");
            agent.destination = goal.transform.position;
            agent.stoppingDistance = attackRange;
            hp = 1;
        }

        void Update() {
            if (canAttack && CheckRange()) {
                Attack();
                StartCoroutine(AttackCooldown());
            }
        }

        public void ReceiveDamage(AttackEnemy attackEnemy) {
            if (CanReceiveAttack(attackEnemy.attackType)) {
                var backward = transform.forward * -1;
                rigid.AddForce(backward * attackEnemy.power, ForceMode.Impulse);
                HP -= attackEnemy.damage;
            }
        }

        private void Death() {
            foreach (var anm in animLst) { anm.SetTrigger(deadkHash); }
            agent.Stop();
			Instantiate (coin, gameObject.transform.position, Quaternion.Euler(90,0,0));
            Destroy(gameObject, 5);
        }

        private bool CheckRange() {
            return Vector3.Distance(goal.transform.position, this.transform.position) < attackRange;
        }

        private void Attack() {
            canAttack = false;
			goal.GetComponent<Health> ().damagePlayer();
            foreach (var anm in animLst) { 
				anm.SetTrigger(attackHash);
			}
        }
        IEnumerator AttackCooldown() {
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }

        //Util
        private bool CanReceiveAttack(AttackType attackType) {
            if (attackType == AttackType.Blue && enemyType == EnemyTypes.Blue) {
                return true;
            }

            if (attackType == AttackType.Red && enemyType == EnemyTypes.Red) {
                return true;
            }

            if (attackType == AttackType.Green && enemyType == EnemyTypes.Green) {
                return true;
            }

            if (attackType == AttackType.Yellow && enemyType == EnemyTypes.Yellow) {
                return true;
            }

            return false;
        }
    }
}