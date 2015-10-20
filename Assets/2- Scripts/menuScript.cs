using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button playText;
	public Button exitText;

	// Use this for initialization
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		playText = playText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;

	
	}

	public void ExitPress(){

		quitMenu.enabled = true;
		playText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){

		quitMenu.enabled = false;
		playText.enabled = true;
		exitText.enabled = true;
	}

	public void StartGame(){

		Application.LoadLevel (1);


	}

	public void ExitGame(){

		Application.Quit ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
