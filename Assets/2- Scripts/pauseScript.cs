using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour {

	public static bool paused = false;

	public Canvas pauseMenu;
	public Button resume;
	public Button quit;

	// Use this for initialization
	void Start () {
		paused = false;
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		resume = resume.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		pauseMenu.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)){
			paused = true;
			pauseMenu.enabled = true;
		}

		if (paused) {

			Time.timeScale = 0;
		
		}else if (!paused){
			Time.timeScale = 1;
		}


	
	}

	public void ResumePressed(){
		
		pauseMenu.enabled = false;
		paused = false;
		Time.timeScale = 1;

	}

	public void QuitPressed(){
		Destroy (this);
		Application.LoadLevel(0);
		

	}
}
