using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {


	public float maxSpeed = 6f;
	public float moveForce = 40f;
	public float jumpForce = 515f;
	public bool jump;
	public GameObject beam;

	public bool canFire = true;
	//The groundcheck variable is used as the point at which we will target
	//when trying to determine if the player is grounded or not. 
	//private Transform groundCheck;
	//
	//But I think I will try it my own way first because there seems to be some
	//other component being pulled in that I'm not aware of. 

	private bool grounded  = false;
	private bool hit = false;
	private Transform groundCheck;
	private Transform beamSpawnPoint;
	private GameController gameController;


	void Awake(){
		groundCheck = transform.Find ("playerGround");
		beamSpawnPoint = transform.Find ("beamSpawnPoint");
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

		//The solution from the 2D game example
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
		}

		if (Input.GetButtonDown ("Fire1") && canFire) {
			Instantiate (beam, beamSpawnPoint.position, beamSpawnPoint.rotation);
			canFire = false;
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");



		if (h * rigidbody2D.velocity.x < maxSpeed) {
			rigidbody2D.AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);		
		}

		if(hit){
			rigidbody2D.velocity = -(rigidbody2D.velocity)*100;
			hit = false;
		}

		if (jump) {
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		} else{
			rigidbody2D.AddForce (new Vector2(0f, -14));
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Enemy") {
			gameController.lives--;
			if(gameController.lives == 0){
				Destroy(this.gameObject);
				Application.LoadLevel(1);
			}
			hit = true;
		} else if(collision.gameObject.tag == "GreenKey"){
			Destroy (collision.gameObject);
			gameController.hasGreenKey = true;
			//TODO: Play a key collection noise
		} else if(collision.gameObject.tag == "RedKey"){
			Destroy (collision.gameObject);
			gameController.hasRedKey = true;
			//TODO: Play a key collection noise
		} else if(collision.gameObject.tag == "BlueKey"){
			Destroy (collision.gameObject);
			gameController.hasBlueKey = true;
			//TODO: Play a key collection noise
		} else if(collision.gameObject.tag == "GreenDoor"){
			if(gameController.hasGreenKey){
				Destroy (collision.gameObject);
			}
			//TODO: Play an unlocking noise
		} else if(collision.gameObject.tag == "RedDoor"){
			if(gameController.hasRedKey){
				Destroy (collision.gameObject);
			}
			//TODO: Play an unlocking noise
		} else if(collision.gameObject.tag == "BlueDoor"){
			if(gameController.hasBlueKey){
				Destroy (collision.gameObject);
			}
			//TODO: Play an unlocking noise
		} else if(collision.gameObject.tag == "FinalDoor"){
			Application.LoadLevel (2);
		} else if(collision.gameObject.tag == "Boundary_Bottom"){
			Application.LoadLevel (1);
		} 
	}
}
