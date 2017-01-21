using System;
using UnityEngine;

namespace Util {
    public enum GravityInfo {
        //The device is in portrait mode, with the device held upright and the home button at the bottom.
        Portrait,
        //The device is in portrait mode but upside down, with the device held upright and the home button at the top.
        PortraitUpsideDown,
        //The device is in landscape mode, with the device held upright and the home button on the right side.
        LandscapeLeft,
        //The device is in landscape mode, with the device held upright and the home button on the left side.
        LandscapeRight,
        //The device is held parallel to the ground with the screen facing upwards.
        FaceUp,
        //The device is held parallel to the ground with the screen facing downwards.
        FaceDown
    }

    public class GravityControl : MonoBehaviour {
        public delegate void GravityShiftEventHandler(GravityInfo e);
        public static event GravityShiftEventHandler OnGravityShift;

        private DeviceOrientation currentDeviceOrientation = DeviceOrientation.LandscapeLeft;

        // Update is called once per frame
        void Update() {
            //transform.Translate(Input.acceleration.x * Time.deltaTime * speed, 0, -Input.acceleration.z * Time.deltaTime);
            if (Input.deviceOrientation != currentDeviceOrientation && Input.deviceOrientation == DeviceOrientation.FaceUp && OnGravityShift != null) {
                currentDeviceOrientation = DeviceOrientation.FaceUp;
                OnGravityShift(GravityInfo.FaceUp);
            }
            if (Input.deviceOrientation != currentDeviceOrientation && Input.deviceOrientation == DeviceOrientation.FaceDown && OnGravityShift != null) {
                currentDeviceOrientation = DeviceOrientation.FaceDown;
                OnGravityShift(GravityInfo.FaceDown);
            }

            if (Input.deviceOrientation != currentDeviceOrientation && Input.deviceOrientation == DeviceOrientation.LandscapeLeft && OnGravityShift != null) {
                currentDeviceOrientation = DeviceOrientation.LandscapeLeft;
                OnGravityShift(GravityInfo.LandscapeLeft);
            }
            if (Input.deviceOrientation != currentDeviceOrientation && Input.deviceOrientation == DeviceOrientation.LandscapeRight && OnGravityShift != null) {
                currentDeviceOrientation = DeviceOrientation.LandscapeRight;
                OnGravityShift(GravityInfo.LandscapeRight);
            }

            if (Input.deviceOrientation != currentDeviceOrientation && Input.deviceOrientation == DeviceOrientation.Portrait && OnGravityShift != null) {
                currentDeviceOrientation = DeviceOrientation.Portrait;
                OnGravityShift(GravityInfo.Portrait);
            }
            if (Input.deviceOrientation != currentDeviceOrientation && Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown && OnGravityShift != null) {
                currentDeviceOrientation = DeviceOrientation.PortraitUpsideDown;
                OnGravityShift(GravityInfo.PortraitUpsideDown);
            }
        }
    }
}
