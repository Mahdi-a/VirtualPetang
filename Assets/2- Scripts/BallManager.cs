using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BallManager : MonoBehaviour {

	public static bool playerOneTurn = true;

	public GameObject playerOneBalls;
	public GameObject ironBallOne;
	public GameObject player1Ball1;
	public GameObject player1Ball2;
	public GameObject player1Ball3;
	public GameObject player1Ball4;

	public static float p1B1Distance = 100f;
	public static float p1B2Distance = 100f;
	public static float p1B3Distance = 100f;
	public static float p1B4Distance = 100f;

	public float[] player1BallsDistance = new float[4];
	public int playerOnePlayed = 0;

	public static int playerOneScore = 0;
	public static int playerOneRoundScore = 0;

	public static bool playerTwoTurn = false;

	public GameObject playerTwoBalls;
	public GameObject ironBallTwo;
	public GameObject player2Ball1;
	public GameObject player2Ball2;
	public GameObject player2Ball3;
	public GameObject player2Ball4;

	public static float p2B1Distance = 100f;
	public static float p2B2Distance = 100f;
	public static float p2B3Distance = 100f;
	public static float p2B4Distance = 100f;

	public float[] player2BallsDistance = new float[4];
	public int playerTwoPlayed = 0;

	public static int playerTwoScore = 0;
	public static int playerTwoRoundScore = 0;

	public float[] gameResult = new float[8];
	public bool gameStarted = false;
	public bool gameEnd = false;

	public GameObject targetBall;

	public Transform[] spawnPoints;

	public bool sceneIsReady = false;
	public static bool paused = false;

	public AudioClip rollOnWood;


	public Canvas pauseMenu;
	public Button resume;
	public Button quit;

	AudioSource gameSound;

	
	void Start ()
	{

		gameSound = GetComponent <AudioSource> ();

		if( (playerOneScore + playerTwoScore) != 0 ){

			DontDestroyOnLoad (this);
			gameEnd = false;

			p1B1Distance = 100f;
			p1B2Distance = 100f;
			p1B3Distance = 100f;
			p1B4Distance = 100f;

			p2B1Distance = 100f;
			p2B2Distance = 100f;
			p2B3Distance = 100f;
			p2B4Distance = 100f;
		}

		paused = false;
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		resume = resume.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		pauseMenu.enabled = false;
	}
	
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)){
			paused = true;
			pauseMenu.enabled = true;
		}
		
		if (paused) {
			
			Time.timeScale = 0;
			
		}else if (!paused){
			Time.timeScale = 1;
		}

		if (gameEnd == false) {
			if (GameObject.Find("player1Ball1") != null && player1Ball1.layer == 16){

				p1B1Distance = calculateDistance(player1Ball1);
				player1BallsDistance[0] = p1B1Distance;
			}
			else{
				player1BallsDistance[0] = 100;
			}
			
			if (GameObject.Find("player1Ball2") != null && player1Ball2.layer == 16){

				p1B2Distance = calculateDistance(player1Ball2);
				player1BallsDistance[1] = p1B2Distance;
			}
			else{
				player1BallsDistance[1] = 100;
			}
			
			if (GameObject.Find("player1Ball3") != null && player1Ball3.layer == 16){

				p1B3Distance = calculateDistance(player1Ball3);
				player1BallsDistance[2] = p1B3Distance;
			}
			else{
				player1BallsDistance[2] = 100;
			}
			
			if (GameObject.Find("player1Ball4") != null && player1Ball4.layer == 16){

				p1B4Distance = calculateDistance(player1Ball4);
				player1BallsDistance[3] = p1B4Distance;
			}
			else{
				player1BallsDistance[3] = 100;
			}
			
			if(GameObject.Find("player2Ball1") != null && player2Ball1.layer == 16){

				p2B1Distance = calculateDistance(player2Ball1);
				player2BallsDistance[0] = p2B1Distance;
			}
			else{
				player2BallsDistance[0] = 100;
			}
			
			if (GameObject.Find("player2Ball2") != null && player2Ball2.layer == 16){

				p2B2Distance = calculateDistance(player2Ball2);
				player2BallsDistance[1] = p2B2Distance;
			}
			else{
				player2BallsDistance[1] = 100;
			}
			
			if (GameObject.Find("player2Ball3") != null && player2Ball3.layer == 16){

				p2B3Distance = calculateDistance(player2Ball3);
				player2BallsDistance[2] = p2B3Distance;
			}
			else{
				player2BallsDistance[2] = 100;
			}
			
			if (GameObject.Find("player2Ball4") != null && player2Ball4.layer == 16){

				p2B4Distance = calculateDistance(player2Ball4);
				player2BallsDistance[3] = p2B4Distance;
			}
			else{
				player2BallsDistance[3] = 100;
			}

			Array.Sort (player1BallsDistance);
			Array.Sort (player2BallsDistance);
		}

		if (checkScene () && gameEnd == false) {

			for (int i = 0; i < 4; i++){
				gameResult[i] = player1BallsDistance[i];
				gameResult[i+4] = player2BallsDistance[i];
			}

			if (targetBall.layer == 16){
				gameStarted = true;
			}

			CheckTurn ();

			if (playerOneTurn && gameStarted) {
				
				switch(playerOnePlayed)
				{
				case 0:

					if (targetBall.layer == 16){
						Instantiate (ironBallOne, spawnPoints [0].position, spawnPoints [0].rotation);
						playerOnePlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
					}
					player1Ball1 = GameObject.Find ("IronBall1(Clone)");
					player1Ball1.name = "player1Ball1";
					player1Ball1.transform.parent = playerOneBalls.transform;
					
					break;
					
				case 1:

					if (player1Ball1.layer == 16){
						Instantiate (ironBallOne, spawnPoints [0].position, spawnPoints [0].rotation);
						playerOnePlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
					
						player1Ball2 = GameObject.Find ("IronBall1(Clone)");
						player1Ball2.name = "player1Ball2";
						player1Ball2.transform.parent = playerOneBalls.transform;
					}
					break;
					
				case 2:

					if (player1Ball2.layer == 16){
						Instantiate (ironBallOne, spawnPoints [0].position, spawnPoints [0].rotation);
						playerOnePlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
						
						player1Ball3 = GameObject.Find ("IronBall1(Clone)");
						player1Ball3.name = "player1Ball3";
						player1Ball3.transform.parent = playerOneBalls.transform;
					}
					break;
					
				case 3:

					if (player1Ball3.layer == 16){
						Instantiate (ironBallOne, spawnPoints [0].position, spawnPoints [0].rotation);
						playerOnePlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
						
						player1Ball4 = GameObject.Find ("IronBall1(Clone)");
						player1Ball4.name = "player1Ball4";
						player1Ball4.transform.parent = playerOneBalls.transform;
					}
					break;
				}
			}

			if (playerTwoTurn && gameStarted) {

				switch(playerTwoPlayed)
				{
				case 0:

					Instantiate (ironBallTwo, spawnPoints [0].position, spawnPoints [0].rotation);
					player2Ball1 = GameObject.Find ("IronBall2(Clone)");
					player2Ball1.name = "player2Ball1";
					player2Ball1.transform.parent = playerTwoBalls.transform;
					playerTwoPlayed++;

					gameSound.clip = rollOnWood;
					gameSound.Play();
					break;

				case 1:

					if (player2Ball1.layer == 16){
						Instantiate (ironBallTwo, spawnPoints [0].position, spawnPoints [0].rotation);
						playerTwoPlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
						
						player2Ball2 = GameObject.Find ("IronBall2(Clone)");
						player2Ball2.name = "player2Ball2";
						player2Ball2.transform.parent = playerTwoBalls.transform;
					}
					break;

				case 2:

					if (player2Ball2.layer == 16){
						Instantiate (ironBallTwo, spawnPoints [0].position, spawnPoints [0].rotation);
						playerTwoPlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
						
						player2Ball3 = GameObject.Find ("IronBall2(Clone)");
						player2Ball3.name = "player2Ball3";
						player2Ball3.transform.parent = playerTwoBalls.transform;
					}
					break;

				case 3:

					if (player2Ball3.layer == 16){
						Instantiate (ironBallTwo, spawnPoints [0].position, spawnPoints [0].rotation);
						playerTwoPlayed++;

						gameSound.clip = rollOnWood;
						gameSound.Play();
						
						player2Ball4 = GameObject.Find ("IronBall2(Clone)");
						player2Ball4.name = "player2Ball4";
						player2Ball4.transform.parent = playerTwoBalls.transform;
					}
					break;
				}
			}
		}

		if (playerOneTurn == false && playerTwoTurn == false && player1Ball4.layer == 16 && player2Ball4.layer == 16 && gameEnd == false && checkScene()) {
			calculateResult ();
		}


	}

	public bool CheckTurn(){

		if (playerOnePlayed == 4 && playerTwoPlayed == 4 && player1Ball4.layer == 16 && player2Ball4.layer == 16) {
			playerOneTurn = false;
			playerTwoTurn = false;
		} else {

			if (playerOneTurn) {

				switch (playerOnePlayed) {
				
				case 0:
					playerOneTurn = true;
					playerTwoTurn = false;
					break;
				
				case 1:
					switch (playerTwoPlayed) {
						
					case 0:
						if (player1Ball1.layer == 16) {
							playerOneTurn = false;
							playerTwoTurn = true;
						} else {
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 1:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 2:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 3:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 4:
						playerOneTurn = true;
						playerTwoTurn = false;
						break;
					}
					break;
				
				case 2:
					switch (playerTwoPlayed) {
						
					case 0:
						playerOneTurn = false;
						playerTwoTurn = true;
						break;
						
					case 1:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 2:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
					
					case 3:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
					
					case 4:
						playerOneTurn = true;
						playerTwoTurn = false;
						break;
					}				
					break;
				
				case 3:
					switch (playerTwoPlayed) {
						
					case 0:
						playerOneTurn = false;
						playerTwoTurn = true;
						break;
						
					case 1:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 2:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 3:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;
						
					case 4:
						playerOneTurn = true;
						playerTwoTurn = false;
						break;
					}
					break;
				
				case 4:
					if (player1Ball4.layer != 16){
						playerOneTurn = true;
						playerTwoTurn = false;
					}
					else{
						playerOneTurn = false;
						if(playerTwoPlayed < 4){
							playerTwoTurn = true;
						}
						else{
							playerTwoTurn = false;
						}
					}
					break;
				}
			}
			else{

				switch (playerTwoPlayed) {
				
				case 0:
					playerOneTurn = false;
					playerTwoTurn = true;
					break;
				
				case 1:
					if (player2Ball1.layer != 16){
						playerOneTurn = false;
						playerTwoTurn = true;
					}
					else{
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
					}

					break;
				
				case 2:

					switch (playerOnePlayed) {
					case 1:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}

						break;

					case 2:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;

					case 3:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;

					case 4:
						playerOneTurn = false;
						playerTwoTurn = true;
						break;
					}
					break;
				
				case 3:
					switch (playerOnePlayed) {
					case 1:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;

					case 2:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;

					case 3:
						if (player1BallsDistance[0] < player2BallsDistance[0]){
							playerOneTurn = false;
							playerTwoTurn = true;
						}else{
							playerOneTurn = true;
							playerTwoTurn = false;
						}
						break;

					case 4:
						playerOneTurn = false;
						playerTwoTurn = true;
						break;

					}
					break;

				case 4:
					if (player2Ball4.layer == 16) {
						playerTwoTurn = false;
						if(playerOnePlayed < 4){
							playerOneTurn = true;
						}
						else{
							playerOneTurn = false;
						}
					} else {
						playerOneTurn = false;
						playerTwoTurn = true;
					}
					break;
				}								
			}
		}

		return playerOneTurn;
	}

	public bool checkScene(){

		int freezedBalls = 0;
		GameObject[] playedBalls = GameObject.FindGameObjectsWithTag ("Played");
		foreach (GameObject playedBall in playedBalls) {

			Rigidbody playedBallRigidbody = playedBall.GetComponent<Rigidbody> ();

			if (playedBallRigidbody.IsSleeping()){
				freezedBalls++;
			}
		}

		if (freezedBalls == playedBalls.Length){
			sceneIsReady = true;
		}else{
			sceneIsReady = false;
		}
		
		return sceneIsReady;
	}

	public float calculateDistance (GameObject Ball){

		float distance = Vector3.Distance (targetBall.transform.position, Ball.transform.position);
		if (Ball.layer == 16) {
			distance = Mathf.Round (distance * 100f) / 100f;
		} else {
			distance = 100;
		}

		return distance;
	}

	void calculateResult (){

		Array.Sort(gameResult);

		for (int i = 0; i < 4; i++) {

			float distance = gameResult[i];
			for ( int j = 0; j < 4; j++){
				if ( distance == player1BallsDistance[j]){
					playerOneRoundScore++;
				}
			}

		}

		playerTwoRoundScore = 4 - playerOneRoundScore;
		gameEnd = true;
		playerOneScore = playerOneScore + playerOneRoundScore;
		playerTwoScore = playerTwoScore + playerTwoRoundScore;

		if (playerOneScore < 13 || playerTwoScore < 13){
			gameEnd = false;
			playerOneRoundScore = 0;
			playerTwoRoundScore = 0;
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void ResumePressed(){
		
		pauseMenu.enabled = false;
		paused = false;
		Time.timeScale = 1;
		
	}
	
	public void QuitPressed(){

		playerOneRoundScore = 0;
		playerOneScore = 0;
		playerTwoRoundScore = 0;
		playerTwoScore = 0;

		p1B1Distance = 100f;
		p1B2Distance = 100f;
		p1B3Distance = 100f;
		p1B4Distance = 100f;

		p2B1Distance = 100f;
		p2B2Distance = 100f;
		p2B3Distance = 100f;
		p2B4Distance = 100f;

		playerOneTurn = true;
		playerTwoTurn = false;
		Application.LoadLevel(0);
		
		
	}
}
