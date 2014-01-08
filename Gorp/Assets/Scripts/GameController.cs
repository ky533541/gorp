using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool hasRedKey;
	public bool hasGreenKey;
	public bool hasBlueKey;

	public int lives;

	public Texture2D livesImage;
	public GUIStyle labelBackground;

	void Awake(){
		hasRedKey = false;
		hasBlueKey = false;
		hasGreenKey = false;

		lives = 3;
	}

	void OnGUI(){
		/*GUI.Box (new Rect (10, 10, 100, 90), "Loader Menu");
		GUI.Button (new Rect (20, 40, 80, 20), "Level 1!");
		GUI.Button (new Rect (20, 75, 80, 20), "Level 2!");*/
		GUI.contentColor = Color.yellow;
		GUI.Box (new Rect (10, Screen.height - 75, 300, 75), "", labelBackground);
		//GUI.Label (new Rect (10, Screen.height - 75, 100, 75), "Lives:", labelBackground);
		for (int i = 0; i < lives; i++) {
			GUI.DrawTexture (new Rect (150 + i*40 , Screen.height - 65,livesImage.width, livesImage.height ), livesImage, ScaleMode.ScaleToFit, true);
		}
	}


}
