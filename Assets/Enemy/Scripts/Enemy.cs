using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy {
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour {
        //References
        private List<Animator> animLst;
        [SerializeField]
        private ParticleSystem onHitParticle;
        [SerializeField]
        private ParticleSystem onDeathParticle;
        private NavMeshAgent agent;
        private Rigidbody rigid;

        //Coins
        public GameObject coin;

        private GameObject ui;
        private Text scoreText;
        private Attack attackScript;


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

		private GameObject audioManager;
		private AudioManager audioM;

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
            ui = GameObject.Find("UI");
            //scoreText = ui.GetComponentInChildren<Text>();
            scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
            attackScript = goal.GetComponent<Attack>();
			audioManager = GameObject.FindGameObjectWithTag ("Audio");
			audioM = audioManager.GetComponent<AudioManager> ();
        }

        void Start() {
            attackHash = Animator.StringToHash("attack");
            deadkHash = Animator.StringToHash("dead");
            agent.destination = goal.transform.position;
            agent.stoppingDistance = attackRange;
            hp = 3;
			transform.localScale += new Vector3 (0.3f, 0.0f, 0.3f);
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
                var part = Instantiate(onHitParticle);
                part.transform.position = transform.position;
				transform.localScale -= new Vector3 (0.1f, 0.0f, 0.1f);
				Collider col = GetComponent<Collider> ();
				col.enabled = false;
				StartCoroutine (WaitForInvulnerability());
            }
        }

		IEnumerator WaitForInvulnerability() {
			yield return new WaitForSeconds(2);
			Collider col = GetComponent<Collider> ();
			col.enabled = true;
		}


        private void Death() {
            foreach (var anm in animLst) { anm.SetTrigger(deadkHash); }
			audioM.PlayDeathEffectEnemy ();
            agent.Stop();
            Instantiate(coin, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            var part = Instantiate(onDeathParticle, transform);
            part.transform.position = transform.position;
            UpdateCoinUI();
            Destroy(gameObject, 5);
        }

        private void UpdateCoinUI() {
            if (scoreText != null) {
                attackScript.increaseScore();
                scoreText.text = attackScript.getPlayerScore() + "";
            }
        }

        private bool CheckRange() {
            return Vector3.Distance(goal.transform.position, this.transform.position) < attackRange;
        }

        private void Attack() {
            canAttack = false;
            goal.GetComponent<Health>().damagePlayer();
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