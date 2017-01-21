using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace Player {
    public enum AttackType {
        Red, Blue, Green, Yellow
    }

    [Serializable]
    public class WeaponType {
        public GameObject prefab;
        public Material material;
        public ParticleSystem ParticleSystem;
        public AttackType AttackType;
        public Image ChargeBarImage;
    }

    [RequireComponent(typeof(SpriteRenderer))]
    public class Attack : MonoBehaviour {
        private SpriteRenderer spriteRenderer;

        //Weapons
        public WeaponType RedWeaponType = new WeaponType() { AttackType = AttackType.Red };
        public WeaponType BlueWeaponType = new WeaponType() { AttackType = AttackType.Blue };
        public WeaponType GreenWeaponType = new WeaponType() { AttackType = AttackType.Green };
        public WeaponType YelloWeaponType = new WeaponType() { AttackType = AttackType.Yellow };

        [SerializeField]
        private WeaponType selectedWeaponType;
        public WeaponType SelectedWeaponType {
            get {
                return selectedWeaponType;
            }
            set {
                selectedWeaponType = value;
                spriteRenderer.material = selectedWeaponType.material;
                selectedWeaponType.ChargeBarImage.fillAmount = 0;
            }
        }

        //Input
        [SerializeField]
        private float chargeSpeed;
        private bool isCharging = false;
        //[SerializeField]
        //private Image chargeBar;
        private float currentCharge;

        void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
            SelectedWeaponType = RedWeaponType;
            InputManager.Instance.RegisterKeyPressedCallback(ProcessPressInput);
            InputManager.Instance.RegisterKeyReleasedCallback(ProcessReleaseInput);
            currentCharge = 0.0f;
        }

        void OnEnable() {
            GravityControl.OnGravityShift += SelectedNewWeapon;
        }


        private void SelectedNewWeapon(GravityInfo gravityInfo) {
            switch (gravityInfo) {
                case GravityInfo.Portrait:
                    SelectedWeaponType = YelloWeaponType;
                    break;
                case GravityInfo.PortraitUpsideDown:
                    SelectedWeaponType = GreenWeaponType;
                    break;
                case GravityInfo.LandscapeLeft:
                    SelectedWeaponType = RedWeaponType;
                    break;
                case GravityInfo.LandscapeRight:
                    SelectedWeaponType = BlueWeaponType;
                    break;
                case GravityInfo.FaceUp:
                    break;
                case GravityInfo.FaceDown:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("gravityInfo", gravityInfo, null);
            }
        }

        private void Fire() {
            isCharging = false;
            selectedWeaponType.ChargeBarImage.fillAmount = 0;
            //Instantiates the particle system
            var ps = Instantiate(selectedWeaponType.ParticleSystem);
            //Sets the strenght of the particle system
            ps.GetComponent<ParticleStrenght>().SetStrength(ComputeAttackStrength());
        }

        private void ProcessPressInput(InputInfo inputInfo) {
            if (inputInfo == InputInfo.AttackCharge) {
                isCharging = true;
                StartCoroutine(Charge());
            }
        }

        private void ProcessReleaseInput(InputInfo inputInfo) {
            if (inputInfo == InputInfo.AttackCharge && isCharging) {
                Fire();
                StopCoroutine(Charge());
            }
        }

        IEnumerator Charge() {
            currentCharge = 0.0f;
            while (isCharging) {
                selectedWeaponType.ChargeBarImage.fillAmount = Mathf.Lerp(0, 1, currentCharge);
                currentCharge += chargeSpeed * Time.deltaTime;
                if (currentCharge >= 1) {
                    Fire();
                }
                yield return null;
            }
        }

        //Receives a charge from 0 to 1 and computes the strenght
        private AttackStrength ComputeAttackStrength() {
            if (currentCharge >= 1) return AttackStrength.VeryStrong;
            if (currentCharge > 0.75f) return AttackStrength.Strong;
            if (currentCharge > 0.50f) return AttackStrength.Normal;
            if (currentCharge > 0.25f) return AttackStrength.Weak;
            else return AttackStrength.Null;
        }

    }
}
