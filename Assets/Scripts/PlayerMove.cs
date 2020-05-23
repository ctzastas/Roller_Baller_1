using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
	
	// Variables for Movement
	public Vector3 movement;
	public Vector3 jump;
	public float speed;
	public float jumpForce = 4f;
	public bool isGrounded;
	// Variable for Physics
	private Rigidbody rollerBaller;   
	// Variables for GUI
	public TextMeshProUGUI life;
	public TextMeshProUGUI score;
	public TextMeshProUGUI gameOver;
	public TextMeshProUGUI finish;
	public GameObject gameOverPanel;
	public GameObject finishPanel;
	private int myScore;
	private int myLife;
	public bool isAlive;
	// Set the position of the player
	public Vector3 setPosition;

	// Use this for initialization
	void Start () {		
		rollerBaller = GetComponent<Rigidbody>();
		setPosition = rollerBaller.position;
		myLife = 3;
		myScore = 0;
		isAlive = true;
		UserInterface();
	}
	// Update is called once per frame
	 void Update() {
		Time.timeScale = 1.5f;
		PauseGame();
		if (myLife < 1) {
			isAlive = false;
			GameOver();
			RestartGame();
		}
	}
	// We are working with FixedUpdate because we use forces;
	void FixedUpdate () {
		MovePlayer();
	}
	// Set the GameOver text inactive during the game
	void Awake() {
		gameOverPanel.SetActive(false);
		finishPanel.SetActive(false);
	}

	// Check if the ball is grounded
	void OnCollisionStay() {
		isGrounded = true;
	}	
	//collider version 
	 void OnCollisionEnter(Collision collision) {
		// If you fall on the ground lose life by 1
	    if (collision.collider.gameObject.CompareTag("Ground")) {
	        collision.collider.gameObject.SetActive(true);
	        myLife--;
	        UserInterface();
	        Debug.Log("My Life is: " + myLife);
	    }
	}	
	 // This is the trigger version - requires the IsTrigger option set
	 void OnTriggerEnter(Collider other) {	
		// If you fall on the water lose life by 1
		if (other.gameObject.CompareTag("Water")) {
			other.gameObject.SetActive(true);
			myLife--;
			rollerBaller.MovePosition(setPosition);
			UserInterface();
			Debug.Log("My Life is: " + myLife);
		}
		// Add life by 1
		if (other.gameObject.CompareTag("Life")) {
			other.gameObject.SetActive(false);
			myLife++;
			UserInterface();
			Debug.Log("My Life is: "+ myLife);
		}
		// Add points by 1
		if (other.gameObject.CompareTag("Points")){
			other.gameObject.SetActive(false);
			myScore++;
			UserInterface();
		}
		// Show message when finish stages
		if (other.gameObject.CompareTag("Finish")) {
			other.gameObject.SetActive(true);
			finishPanel.SetActive(true);
			finish.text = "YOU FINISH STAGE 1";
			Time.timeScale = 0;
			SceneManager.LoadScene("MainMenu");
		}
	}
	 // Movement of the player 
	 void MovePlayer() {
		 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		 jump = new Vector3(0, 1, 0);
		 if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			 rollerBaller.AddForce(jump * jumpForce, ForceMode.Impulse);
			 isGrounded = false;
		 }
		 else {
			 rollerBaller.AddForce(movement * speed, ForceMode.Acceleration);
		 }
	 }
	 // Main Menu of the game	
	 void MainMenu() {
		 SceneManager.LoadScene("MainMenu");
	 }
	 // Show the score and life of the player 
	 void UserInterface() {
		 life.text =  "LIFE: " + myLife;
		 score.text = "APPLES: " + myScore;	 
	 }
	 // Pause the game and load Main Menu scene
	 void PauseGame(){
		 if (Input.GetKey(KeyCode.Escape)) {
			Time.timeScale = 0;
			SceneManager.LoadScene(sceneName:"MainMenu");
		 }
	 }
	 // Resume the game 
	 void ResumeGame() {		 		 
		 Time.timeScale = 1.5f;		 
	 }
	// Restart the game when you lose all your lifes
	 void RestartGame() {
		 SceneManager.LoadScene("RollerBallerScene");
	 }
	// Set the text for game over
	 void GameOver() {
		 if (myLife < 1) {
			 gameOverPanel.SetActive(true);
			 gameOver.text = "GAME OVER";
			 Time.timeScale = 0;
		 }
	 }
}