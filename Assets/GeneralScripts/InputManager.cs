using System;
using UnityEngine;

namespace Util {
    public enum InputInfo {
        AttackCharge
    }

    public class InputManager : Singleton<InputManager> {
        public Action<InputInfo> keyPressed, keyReleased;
        private bool charging = false;

        public void RegisterKeyPressedCallback(Action<InputInfo> callback) {
            keyPressed += callback;
        }

        public void UnregisterKeyPressedCallback(Action<InputInfo> callback) {
            if (keyPressed != null) keyPressed -= callback;
        }

        public void RegisterKeyReleasedCallback(Action<InputInfo> callback) {
            keyReleased += callback;
        }

        public void UnregisterKeyReleasedCallback(Action<InputInfo> callback) {
            if (keyReleased != null) keyReleased -= callback;
        }

        void Update() {
            if (Input.touchCount == 1 && charging == false) {
                if (keyPressed != null) keyPressed(InputInfo.AttackCharge);
                charging = true;
            }

            if (Input.touchCount == 0 && charging == true) {
                if (keyPressed != null) keyReleased(InputInfo.AttackCharge);
                charging = false;
            }
        }
    }
}
