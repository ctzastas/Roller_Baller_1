using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	
	// Variables for the camera move
	public GameObject playerBall;
	private Vector3 offSet;
	private Vector3 rotateValue;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		offSet = transform.position - playerBall.transform.position;
	}
	// Update is called once per frame
	void Update() {
		// Rotate camera with mouse
		y = Input.GetAxis("Mouse X");
		x = Input.GetAxis("Mouse Y");
		rotateValue = new Vector3(x, y * -1, 0);
		transform.eulerAngles = transform.eulerAngles - rotateValue;
	}
	// Update is called once per frame
	void LateUpdate () {
		// Follow player
		transform.position = playerBall.transform.position + offSet;
	}
}
