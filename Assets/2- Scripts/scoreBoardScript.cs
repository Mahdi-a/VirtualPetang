using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreBoardScript : MonoBehaviour {

	public float p1B1distance;
	public float p1B2distance;
	public float p1B3distance;
	public float p1B4distance;

	public float p2B1distance;
	public float p2B2distance;
	public float p2B3distance;
	public float p2B4distance;

	public Text player1Ball1Distance;
	public Text player1Ball2Distance;
	public Text player1Ball3Distance;
	public Text player1Ball4Distance;

	public Text player2Ball1Distance;
	public Text player2Ball2Distance;
	public Text player2Ball3Distance;
	public Text player2Ball4Distance;

	public Text gameScorePlayer1;
	public Text gameScorePlayer2;

	public Text playerOne;
	public Text playerTwo;




	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {

		if (BallManager.playerOneTurn) {
			playerOne.color = Color.green;
			playerTwo.color = Color.white;
		} else {
			playerOne.color = Color.white;
			playerTwo.color = Color.green;
		}

		p1B1distance = BallManager.p1B1Distance;
		if (p1B1distance == 100) {
			player1Ball1Distance.text = "--";
		} else {
			player1Ball1Distance.text = p1B1distance.ToString ();
		}

		p1B2distance = BallManager.p1B2Distance;
		if (p1B2distance == 100) {
			player1Ball2Distance.text = "--";
		} else {
			player1Ball2Distance.text = p1B2distance.ToString ();
		}

		p1B3distance = BallManager.p1B3Distance;
		if (p1B3distance == 100) {
			player1Ball3Distance.text = "--";
		} else {
			player1Ball3Distance.text = p1B3distance.ToString ();
		}

		p1B4distance = BallManager.p1B4Distance;
		if (p1B4distance == 100) {
			player1Ball4Distance.text = "--";
		} else {
			player1Ball4Distance.text = p1B4distance.ToString ();
		}

		p2B1distance = BallManager.p2B1Distance;
		if (p2B1distance == 100) {
			player2Ball1Distance.text = "--";
		} else {
			player2Ball1Distance.text = p2B1distance.ToString ();
		}

		p2B2distance = BallManager.p2B2Distance;
		if (p2B2distance == 100) {
			player2Ball2Distance.text = "--";
		} else {
			player2Ball2Distance.text = p2B2distance.ToString ();
		}

		p2B3distance = BallManager.p2B3Distance;
		if (p2B3distance == 100) {
			player2Ball3Distance.text = "--";
		} else {
			player2Ball3Distance.text = p2B3distance.ToString ();
		}

		p2B4distance = BallManager.p2B4Distance;
		if (p2B4distance == 100) {
			player2Ball4Distance.text = "--";
		} else {
			player2Ball4Distance.text = p2B4distance.ToString ();
		}

		gameScorePlayer1.text = BallManager.playerOneScore.ToString ();
		gameScorePlayer2.text = BallManager.playerTwoScore.ToString ();
	}
}
