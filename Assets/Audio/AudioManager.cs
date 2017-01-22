using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip coin_effect;
	public AudioClip death_effect;
	public AudioClip hitEffect;

	private AudioSource source;

	// Use this for initialization

	void Awake () {
		source = GetComponentInChildren<AudioSource>();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayCoinEffect (){
		source.PlayOneShot(coin_effect,6.0f);
	}

	public void PlayDeathEffectEnemy (){
		source.PlayOneShot(death_effect, 6.0f);
	}
	public void PlayHitEffectEnemy (){
		source.PlayOneShot(hitEffect, 6.0f);
	}
}
