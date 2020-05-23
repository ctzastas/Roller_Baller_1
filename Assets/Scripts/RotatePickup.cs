using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickup : MonoBehaviour {
	float rotX, rotY, rotZ;
	// Use this for initialization
	void Start () {
		// Rotate the objects
		rotX = 45 * Random.value;
		rotY = 45 * Random.value;
		rotZ = 45 * Random.value;
	}	
	// Update is called once per frame
	void Update () {    
		transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.deltaTime);
	}
}
