using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {


	public float maxSpeed = 5f;
	public float moveForce = 40f;
	public float jumpForce = 300f;
	public bool jump;


	//The groundcheck variable is used as the point at which we will target
	//when trying to determine if the player is grounded or not. 
	//private Transform groundCheck;
	//
	//But I think I will try it my own way first because there seems to be some
	//other component being pulled in that I'm not aware of. 

	private bool grounded  = false;
	private Transform groundCheck;


	void Awake(){
		groundCheck = transform.Find ("playerGround");
	}
	
	// Update is called once per frame
	void Update () {

		/*RaycastHit2D hit = Physics2D.Raycast (transform.position, (-1)*Vector2.up, 1);
		if (hit.collider.tag == "Ground") {
			Debug.Log ("You cast and hit the ground");
		} else {
			Debug.Log ("You didn't hit it");
			Debug.Log (hit.collider.tag);
		}*/

		/*RaycastHit2D hitGround = Physics2D.Linecast(transform.position, groundCheck.position);

		if(hitGround){
			grounded = true;
			Debug.Log ("On ground");
		} else {
			grounded = false;
			Debug.Log ("Not on the ground bro");
		}

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
		}*/

		//The solution from the 2D game example
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
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

		if (jump) {
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Enemy") {
			Destroy(this.gameObject);
			Debug.Log("Why isnt this prick dead");

		}
	}
}
