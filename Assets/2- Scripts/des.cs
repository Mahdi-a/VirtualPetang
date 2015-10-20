using UnityEngine;
using System.Collections;

public class des : MonoBehaviour {

	public AudioClip hitWoodClip;
	public AudioClip hitGrassClip;

	AudioSource gameSound;

	void OnCollisionEnter(Collision col){
		gameSound = GetComponent <AudioSource> ();

		if ( col.gameObject.name == "Terrain"){
			gameSound.clip = hitGrassClip;
			gameSound.Play();
			print ("yesss");

		}

		if ( col.gameObject.name == "Cube (1)"){
			gameSound.clip = hitWoodClip;
			gameSound.Play();
			print ("No");
			
		}
	}
}
