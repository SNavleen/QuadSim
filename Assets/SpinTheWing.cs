using UnityEngine;
using System.Collections;

public class SpinTheWing : MonoBehaviour {

	//public static float MAX_SPEED;
	public static float bladeSpeed;
	//public static float MIN_VALUE = 0;
	// Use this for initialization
	void Start () {
		bladeSpeed = 14;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (0, Time.deltaTime * 1000, 0);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y + bladeSpeed, 0);
		//float translation = Time.deltaTime * 10; // Move 10 m/s
	}
}
