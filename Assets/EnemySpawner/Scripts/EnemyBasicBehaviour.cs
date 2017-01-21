using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawner;

namespace Spawner{
	public class EnemyBasicBehaviour : MonoBehaviour {

		public float speed;
		private Vector3 target = new Vector3(0,1,0);

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target, step);
		}
	}
}