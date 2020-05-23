using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public int life = 3;

	public void OnTriggerEnter() {
		// This is the trigger version - requires the IsTrigger option set

		if (gameObject.CompareTag("Water"))
		{
			gameObject.SetActive(true);
			life--;
			Debug.Log("My Life is: " + life);
		}		
	}
}
