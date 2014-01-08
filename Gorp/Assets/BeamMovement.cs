using UnityEngine;
using System.Collections;

public class BeamMovement : MonoBehaviour {

	public float maxSpeed = 6f;
	public float moveForce = 40f;
	
	// Update is called once per frame
	void FixedUpdate () {

		float h = -1f;

		if (h * rigidbody2D.velocity.x < maxSpeed) {
			rigidbody2D.AddForce (Vector2.right * h * moveForce);
		}
		
		if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed) {
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);		
		}


	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy (this.gameObject);
	}
}
