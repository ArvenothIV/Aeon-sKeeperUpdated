using UnityEngine;
using System.Collections;

public class ProgressionInteractionHouse5 : MonoBehaviour {
	public playerController player;
	public FadeInAndOut fadeScript;
	
	public WorldButtonInteraction chestScript;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		if (Progression.previousScene == "Outsidehome3") {
			player.GetComponent<CharacterController>().transform.position = new Vector3(1f, 1f, -1f);
		}
		else if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		chestScript = GameObject.Find ("Chest").GetComponent<WorldButtonInteraction>();
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (chestScript.clicked == true){
			if(GUI.Button (new Rect (Screen.width/2f - (chestScript.messageLength*2.2f)/2f,
			    Screen.height/2.8f - 25, chestScript.messageLength*2.2f, chestScript.messageHeight), "Take Hatchet")){
				chestScript.clicked = false;
				Progression.hasHatchet = true;
			}
		}
	}
}
