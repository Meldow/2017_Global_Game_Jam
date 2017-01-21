using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy {
    public class LifeColor : MonoBehaviour {

        //public EnemyTypes color;
        //public Color colorX;
        [SerializeField]
        private Image image; 


        private Color color;
        public Color Color {
            get { return color; }
            set {
                color = value;
                image.color = color;
            }
        }

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }
    }
}