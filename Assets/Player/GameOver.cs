using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame(){
		SceneManager.LoadScene ("main_menu");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
