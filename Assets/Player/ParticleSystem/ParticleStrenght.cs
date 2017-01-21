using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public enum AttackStrength {
        Weak, Normal, Strong, VeryStrong, Null
    }

    [RequireComponent(typeof(SphereCollider))]
    public class ParticleStrenght : MonoBehaviour {
        [SerializeField]
        private List<ParticleSystem> cloudLst;

        public void SetStrength(AttackStrength attackStrength) {
            switch (attackStrength) {
                case AttackStrength.Null:
                    foreach (var cloud in cloudLst) {
                        var dmpn = cloud.limitVelocityOverLifetime;
                        dmpn.dampen = 0.5f;
                    }
                    break;
                case AttackStrength.Weak:
                    foreach (var cloud in cloudLst) {
                        var dmpn = cloud.limitVelocityOverLifetime;
                        dmpn.dampen = 0.2f;
                        StartCoroutine(ExpandCollider(2.0f));
                    }
                    break;
                case AttackStrength.Normal:
                    foreach (var cloud in cloudLst) {
                        var dmpn = cloud.limitVelocityOverLifetime;
                        dmpn.dampen = 0.1f;
                        StartCoroutine(ExpandCollider(4.0f));
                    }
                    break;
                case AttackStrength.Strong:
                    foreach (var cloud in cloudLst) {
                        var dmpn = cloud.limitVelocityOverLifetime;
                        dmpn.dampen = 0.05f;
                    }
                    break;
                case AttackStrength.VeryStrong:
                    foreach (var cloud in cloudLst) {
                        var dmpn = cloud.limitVelocityOverLifetime;
                        dmpn.dampen = 0.025f;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("attackStrength", attackStrength, null);
            }
        }

        IEnumerator ExpandCollider(float targetRadius) {
            var collider = GetComponent<SphereCollider>();
            var currentRadius = 0;
            var t = 0.0f;
            while (collider.radius <= targetRadius) {
                collider.radius = Mathf.Lerp(0, targetRadius, t);
                t += Time.deltaTime;

            }
            yield return null;
        }
    }
}
