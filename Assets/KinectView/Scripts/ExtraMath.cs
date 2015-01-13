using UnityEngine;
using System.Collections;

public class ExtraMath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public static float dotProduct(Vector3 a, Vector3 b){
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}
	public static float length(Vector3 a){
		return Mathf.Sqrt (a.x * a.x + a.y * a.y + a.z * a.z); 
	}
	public static float distance(Vector3 a, Vector3 b){
		return Mathf.Sqrt (Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2) + Mathf.Pow(a.z - b.z, 2)); 
	}
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
