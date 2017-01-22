using System;
using System.Collections;
using UnityEngine;

namespace Player {
    public enum AttackStrength {
        Weak, Normal, Strong, VeryStrong, Null
    }

    [RequireComponent(typeof(SphereCollider))]
    public class ParticleStrenght : MonoBehaviour {
        [SerializeField]
        private ParticleSystem ringParticle;

        public void SetStrength(AttackStrength attackStrength) {
            var size = ringParticle.main;
            switch (attackStrength) {
                case AttackStrength.Null:
                    size.startSize = 0;
                    break;
                case AttackStrength.Weak:
                    size.startSize = 8;
                    StartCoroutine(ExpandCollider(8.5f, 0.85f));
                    break;
                case AttackStrength.Normal:
                    size.startSize = 13;
                    StartCoroutine(ExpandCollider(20.0f, 1.7f));
                    break;
                case AttackStrength.Strong:
                    size.startSize = 18;
                    StartCoroutine(ExpandCollider(25.0f, 2.2f));
                    break;
                case AttackStrength.VeryStrong:
                    size.startSize = 22;
                    StartCoroutine(ExpandCollider(30.0f, 2.6f));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("attackStrength", attackStrength, null);
            }
        }

        IEnumerator ExpandCollider(float targetRadius, float speed) {
            var collider = GetComponent<SphereCollider>();
            var currentRadius = 0;
            var t = 0.0f;
            while (collider.radius <= targetRadius) {
                //Debug.Log(Mathf.Lerp(0, targetRadius, t));
                collider.radius += Time.deltaTime * speed;
                //t += Time.deltaTime;
                yield return null;
            }
        }
    }
}
