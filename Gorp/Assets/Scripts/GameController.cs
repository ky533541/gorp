using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool hasRedKey;
	public bool hasGreenKey;
	public bool hasBlueKey;

	void Awake(){
		hasRedKey = false;
		hasBlueKey = false;
		hasGreenKey = false;
	}


}
