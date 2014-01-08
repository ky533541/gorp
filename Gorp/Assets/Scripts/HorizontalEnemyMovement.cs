using UnityEngine;
using System.Collections;

public class HorizontalEnemyMovement : MonoBehaviour {

	public float speed = 3.5f;

	private float leftBoundary;
	private float rightBoundary;
	private float direction;
	private Vector3 movement;
	private Transform currentTransform;

	void Awake(){
		leftBoundary = this.transform.position.x - 2.5f;
		rightBoundary = this.transform.position.x + 2.5f;
		currentTransform = this.transform;
		movement = new Vector3 (0f, 0f, 0f);
		direction = 1.0f;
	}

	void Update(){

		movement.x = direction * speed * Time.deltaTime;

		//Logic here to flip the direction if need be
		if (currentTransform.position.x < leftBoundary && direction < 0.0f) {
			direction = 1.0f;
		} else if(currentTransform.position.x > rightBoundary && direction > 0.0f){
			direction = -1.0f;
		}

		currentTransform.Translate (movement);

	}
	
}
