using UnityEngine;
using System.Collections;

public class playSounds : MonoBehaviour {

	public AudioClip hitWoodClip;
	public AudioClip hitGrassClip;
	public AudioClip hitBall;
	public AudioClip rollOnGrass;
	public AudioClip rollOnWood;

	AudioSource gameSound;

	void OnCollisionEnter(Collision col){

		gameSound = GetComponent <AudioSource> ();

		if ( col.gameObject.name == "Terrain"){
			gameSound.clip = hitGrassClip;
			gameSound.Play();	
		}
		
		if ( col.gameObject.name == "Cube (1)"){
			gameSound.clip = hitWoodClip;
			gameSound.Play();
		}

		if ( col.gameObject.tag == "Played"){
			gameSound.clip = hitBall;
			gameSound.Play();
		}
	}
}
