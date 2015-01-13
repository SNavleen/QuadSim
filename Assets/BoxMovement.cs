using UnityEngine;
using System.Collections;

public class BoxMovement : MonoBehaviour {

	private float horizontalAnglularVel = 0;
	private float zAngularVel = 0;
	private float verticalAngularVel = 0;

	float MAX_VELX = 20;
	float MAX_VELY = 20;
	float MAX_VELZ = 20;
	
	//store a bunch of constants
	float Acceleration = 0;
	const float xMultiple = 0.5f;//1;
	const float yMultiple = 0.25f;//0.5f;
	const float zMultiple = 0.25f;//0.5f;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// when user presses escape key...
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			// quit application...
			Application.Quit();
		}

		//resetRotation ();
		//float acceleration2 = ExtraMath.distance (BodySourceView.handLeftTip, BodySourceView.handLeft); //+ ExtraMath.distance(BodySourceView.handRightTip, BodySourceView.handRight))/2;
		//Debug.Log ("acceleration: " + acceleration2);
		//return;
		//float bladeAcceleration2 = (ExtraMath.distance(BodySourceView.handLeftTip, BodySourceView.handLeft) + ExtraMath.distance(BodySourceView.handRightTip, BodySourceView.handRight))/2;
		//Acceleration = 2 - bladeAcceleration2 * 2;
		//Debug.Log ("Acceleration: " + Acceleration);
		//return;

		bool isMoving = false;

		/*float bladeAcceleration = (ExtraMath.distance(BodySourceView.handLeftTip, BodySourceView.handLeft) + ExtraMath.distance(BodySourceView.handRightTip, BodySourceView.handRight))/2;
		if (Mathf.Abs (bladeAcceleration) > 0.55) {
			//Acceleration = 2 - bladeAcceleration * 2;
			bladeAcceleration = Mathf.Abs (1.0f - bladeAcceleration);
			//SpinTheWing.bladeSpeed = SpinTheWing.MIN_VALUE + bladeAcceleration * SpinTheWing.MIN_VALUE;
		}*/
		//Debug.Log ("Acceleration: " + Acceleration);
		//Acceleration = 0;

		/*if (Acceleration <= 0.4) {
			return;

			horizontalAnglularVel = 0;
			zAngularVel = 0;
			verticalAngularVel = 0;
			
			MAX_VELX = 20;
			MAX_VELY = 20;
			MAX_VELZ = 20;
			
			//store a bunch of constants
			Acceleration = 0;
		}*/
		//Acceleration = 0;
		//Debug.Log("Acceleration: " + Acceleration);
		//move horizontal
		float moveHorizontally = BodySourceView.head.x - BodySourceView.neck.x;
		if (moveHorizontally > 0.5 || moveHorizontally < -0.5) {
			//transform.position =  new Vector3(transform.position.x + moveHorizontally * HorizontalProportion, transform.position.y, transform.position.z);
			float newRotation = moveBody (moveHorizontally, 0, 0, transform.eulerAngles.z, horizontalAnglularVel);
			horizontalAnglularVel = newRotation - transform.eulerAngles.z;
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
			isMoving = true;
		}

		//move vertical
		float moveZPosition = BodySourceView.midspine.z - BodySourceView.neck.z;
		if (moveZPosition > 0.5 || moveZPosition < -0.5) {
			float newRotation = moveBody (0, 0, moveZPosition, transform.eulerAngles.x, verticalAngularVel);

			verticalAngularVel = newRotation - transform.eulerAngles.x;
			transform.eulerAngles = new Vector3(newRotation, transform.eulerAngles.y, transform.eulerAngles.z);
			isMoving = true;
		}

		Vector3 midPointOfWrists = (BodySourceView.wristLeft + BodySourceView.wristRight)/2;//new Vector3(BodySourceView.wristLeft.x + BodySourceView.wristRight.x, BodySourceView.wristLeft.y + BodySourceView.wristRight.y, BodySourceView.wristLeft.z + ));
		if (Mathf.Abs(BodySourceView.wristLeft.z - BodySourceView.wristRight.z) < 0.5f) {//up and down code
						float moveYPosition = ExtraMath.distance (midPointOfWrists, BodySourceView.midspine);
						if (moveYPosition > 0.5 || moveYPosition < -0.5) {
								moveYPosition = (moveYPosition - 3) / (-2);
								float unusedVariable = moveBody (0, Mathf.Round (moveYPosition), 0, 0, 0);
						}
		} else {
			float difference = BodySourceView.wristLeft.z - BodySourceView.wristRight.z;
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - difference, transform.eulerAngles.z);


		}


		if (!isMoving) {
			resetRotation();
		}

		checkBounds ();

	}

	private void checkBounds(){
		if (transform.position.y <= 1.25) {
			transform.position = new Vector3 (transform.position.x, 1.25f, transform.position.z);
		}
		else if (transform.position.y >= 256) {
			transform.position = new Vector3 (transform.position.x, 256.0f, transform.position.z);
		}

		if (transform.position.z <= -152) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 152.0f);
		}
		else if (transform.position.z >= 152) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, -152.0f);
		}

		if (transform.position.x <= -152) {
			transform.position = new Vector3 (152.0f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x >= 152) {
			transform.position = new Vector3 (-152.0f, transform.position.y, transform.position.z);
		}

	}

	private void resetRotation(){
		float[] allRotationAxis = {	transform.eulerAngles.x,
		                           	transform.eulerAngles.y, 
									transform.eulerAngles.z};

		for (int i = 0; i < 3; i++) {
			if ( allRotationAxis[i] == 0)
				continue;
			float tempRotationStore = allRotationAxis[i] - 180;
			if (Mathf.Abs(tempRotationStore) > 1.0f) {
				tempRotationStore = tempRotationStore + (tempRotationStore / Mathf.Abs(tempRotationStore));
			} else {
				tempRotationStore = 0.0f;
			}//end if*/
			allRotationAxis[i] = tempRotationStore + 180;
		}//end for

		//Debug.Log ("x: " + allRotationAxis[0] + " y: " + allRotationAxis[1] + " z: " + allRotationAxis[2]);
		transform.eulerAngles = new Vector3 (allRotationAxis[0], allRotationAxis[1], allRotationAxis[2]);
	}

	private float moveBody(float moveX, float moveY, float moveZ, float rotation, float roationVel){
		transform.position =  new Vector3(transform.position.x + moveX * xMultiple /* Acceleration*/, 
		                                  transform.position.y + moveY * yMultiple /* * Acceleration*/, 
		                                  transform.position.z + moveZ * zMultiple /* * Acceleration*/); 

		if(rotation >= 30 && rotation <= 335){
			//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
			roationVel = 0;
			return rotation;
		}

		if (moveX + moveY + moveZ > 0)
			roationVel -= 0.05f; //transform.eulerAngles.z 
		else
			roationVel += 0.05f;

		return rotation + roationVel;
		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + horizontalAnglularVel);

		/*
		if(transform.eulerAngles.z >= 30 && transform.eulerAngles.z <= 335){
			//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
			horizontalAnglularVel = 0;
			return;
		}
		if (moveX > 0)
			horizontalAnglularVel -= 0.05f; //transform.eulerAngles.z 
		else
			horizontalAnglularVel += 0.05f;
		
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + horizontalAnglularVel);
		*/
	}
	/*
	void moveBodyHorizontally(float moveHorizontally){
		//Vector3 AB = BodySourceView.shoulderLeft - BodySourceView.neck;
		//Vector3 BC = BodySourceView.neck - BodySourceView.head;
		//float angle = Mathf.Acos(ExtraMath.dotProduct (AB, BC)/(ExtraMath.length(AB) * ExtraMath.length(BC)));

		transform.position =  new Vector3(transform.position.x + moveHorizontally * HorizontalProportion, transform.position.y, transform.position.z);

		//Debug.Log ("angle: " + angle);
		//if (moveHorizontally < 0)
		//				angle = angle * (-1);
		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, angle*10);

		if(transform.eulerAngles.z >= 30 && transform.eulerAngles.z <= 330){
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
			horizontalAnglularVel = 0;
			return;
		}
		if (moveHorizontally > 0)
			horizontalAnglularVel -= 0.05f; //transform.eulerAngles.z 
		else
			horizontalAnglularVel += 0.05f;

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + horizontalAnglularVel);


	}*/
}
