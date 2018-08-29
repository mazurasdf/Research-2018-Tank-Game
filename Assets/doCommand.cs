using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doCommand : MonoBehaviour {

	GameObject turret;
	GameObject wheels;
	public float turningSpeed;
	private bool CR_Running = false;//used to tell if a coroutine is still running or not

	void Start () {
		turret = this.gameObject.transform.GetChild (3).gameObject;
		wheels = this.gameObject.transform.GetChild (2).gameObject;
	}

	void Update () {
		
	}

	//this function will move the tank forward or backward
	public IEnumerator moveTank(string direction, float seconds){
		Debug.Log ("hello this is move tank in doCommand");

		while(CR_Running) {
			yield return null;
		}

		CR_Running = true;

		//movement currently set to what the current velocity is
		Vector3 movement = GetComponent<Rigidbody> ().velocity;

		Debug.Log (direction);

		//switch will change movement depending on what was typed by the user
		switch (direction) {
		case "forward":
			movement = Vector3.forward;
			break;
		case "backward":
			movement = Vector3.back;
			break;
		case "stop":
			movement = Vector3.zero;
			break;
		}

		//actual velocity is now changed to the corresponding movement
		GetComponent<Rigidbody> ().velocity = movement;
		//wait for desired time
		yield return new WaitForSeconds (seconds);
		//and now stop the tank
		GetComponent<Rigidbody> ().velocity = Vector3.zero;

		CR_Running = false;
		StopCoroutine ("moveTank");

		yield return null;
	}

	//lol what's going on here
	public IEnumerator turnTank(float direction){
		/*
		Debug.Log ("hello welcome to uhhhhhhhhh turnTank in doCommand. Is that for here or to go?");

		while(CR_Running) {
			yield return null;
		}

		CR_Running = true;

		Vector3 turningDirection = new Vector3 (0, 30, 0);

		for (float i = 0f; i < 1; i += .01) {
			this.transform.localRotation = turningDirection;
			yield return new WaitForSeconds (.05f);
		}
			
		CR_Running = false;
		StopCoroutine ("turnTank");
		*/
		yield return null;
	}

	//this will change the angle the turret is pointed at
	public IEnumerator changeAngle(float angle){
		Debug.Log ("hello this is change angle in doCommand");

		while(CR_Running) {
			yield return null;
		}

		CR_Running = true;

		float finalAngle = 0;

		//this will loop 50 times, incrementing a little each time. we did this to increment the angle of rotation a little bit each frame,
		//which will make it look animated, rather than the turret immediately pointing in one direction. If you can understand this code, you are amazing
		for(float i = 0f;i < 1f; i += .02f) {
			//there were weird issues with inputting a negative number for the angle. So we tried to make a solution. It works, but the turret will
			//sometimes spin the wrong way. But it arrives at the correct location so...

			//if the angle is negative and the current rotation is positive
			if ((angle < 0) && (turret.transform.eulerAngles.y >= 0)) {
					//incrementally change the angle until it reaches the final angle
					finalAngle = ((angle + (360 - turret.transform.eulerAngles.y)) * i);
					turret.transform.Rotate (0, finalAngle, 0);
					yield return new WaitForSeconds (.005f);
			}
			else{
				//incrementally change the angle until it reaches the final angle
				finalAngle = ((angle - turret.transform.eulerAngles.y) * i);
				turret.transform.Rotate (0, finalAngle, 0);
				yield return new WaitForSeconds (.005f);
			}

		}

		CR_Running = false;
		StopCoroutine ("changeAngle");
		//yield return null;
	}
		
	//move the tank forward and turn to the angle you direct it to. works weird with negative numbers and it's also kinda broken, oh my...
	public IEnumerator turn(float angle){
		Debug.Log ("hello this is turn in doCommand");

		while(CR_Running) {
			yield return null;
		}

		CR_Running = true;

		//same as change angle, run incrementally
		for (float i = 0f; i <= .08f; i += .001f) {
			//change the angle incrementally
			this.transform.Rotate (0, ((angle - transform.eulerAngles.y) * i), 0);
			//move forward a little bit
			this.transform.Translate (Vector3.forward * turningSpeed);
			yield return null;
		}

		//stop the tank
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		Debug.Log ("done turning");

		CR_Running = false;
		StopCoroutine ("turn");

	}

}
