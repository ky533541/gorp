using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	void Awake(){
		offset = new Vector3 (0, 0, -300);
	}

	void FixedUpdate(){
		this.transform.position = player.transform.position + offset;
	}
}
