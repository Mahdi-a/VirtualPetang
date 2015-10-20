using UnityEngine;
using System.Collections;

public class TargetBallMovement : MonoBehaviour {

	public GameObject myHand;
	public GameObject targetBall;
	public bool ballInHand;
	public Rigidbody targetBallRigidbody;
	public SphereCollider targetBallCollider;

	// Use this for initialization
	void Start () {
		targetBall = GameObject.Find ("TargetBall");
		targetBallRigidbody.constraints = RigidbodyConstraints.FreezePosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		myHand = GameObject.Find ("MagneticPinchHand(Clone)");

		if (GameObject.Find ("MagneticPinchHand(Clone)") != null) {

			ballInHand = myHand.GetComponent<MagneticPinch> ().grabbedBall;

		} else {

			ballInHand = false;
		}

		if (ballInHand) {

			targetBallRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

			targetBallRigidbody.angularDrag = 0.3f;

			if (targetBall.layer == 15){
				targetBallCollider.radius = 1.4f;
			}
		
		} else {
		
			targetBallRigidbody.constraints = RigidbodyConstraints.None;

			targetBallCollider.radius = 0.5f;
		}

		if (!targetBallRigidbody.IsSleeping()){

			targetBallRigidbody.angularDrag = targetBallRigidbody.angularDrag * 1.03f;
		}
	}
}