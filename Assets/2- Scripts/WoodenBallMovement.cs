using UnityEngine;
using System.Collections;
using Leap;

public class WoodenBallMovement : MonoBehaviour {

	public GameObject myHand;
	public bool ballInHand;
	public Rigidbody ballRigidbody;

	
	void Start () {

		ballRigidbody.constraints = RigidbodyConstraints.FreezePosition;
	}
	

	void FixedUpdate () {

		myHand = GameObject.Find ("MagneticPinchHand(Clone)");

		if (GameObject.Find ("MagneticPinchHand(Clone)") != null) {
		
			ballInHand = myHand.GetComponent<MagneticPinch> ().grabbedBall;

		} else {

			ballInHand = false;
		}

		if (ballInHand) {

			ballRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			ballRigidbody.angularDrag = 0.2f;
		
		} else {

			ballRigidbody.constraints = RigidbodyConstraints.None;
		}

		if (!ballRigidbody.IsSleeping()){

			ballRigidbody.angularDrag = ballRigidbody.angularDrag * 1.01f;
		}
	}
}


