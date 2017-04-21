using UnityEngine;
using System.Collections;

public class DialogueJailer : MonoBehaviour {

	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("vinegar").GetComponent<WorldButtonInteraction>();
		stage = 0;
		
		messageLength *= (Screen.width/100f);
		messageHeight *= (Screen.height/100f);
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin.button.fontSize = (int)(Screen.height / fontSize);
		GUI.skin.box.fontSize = (int)(Screen.height / fontSize);
		
		if(npcScript.clicked == true && stage == 0) {
			stage = 1;
		}
		
		if(npcScript.isTriggered && Progression.progress == 14){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "I think I'm failing at stealing some vinegar.")) {
					stage = 2;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Hey! What do you think you're doing!?");
				break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "So, can I have some vinegar please?")) {
					stage = 3;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "You could've just asked.");
				break;
			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 3f) / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 3f, messageHeight), "And what is that?")) {
					stage = 4;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "There's is something I'd like and I'm willing to trade for it.");
				break;
			case 4:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "Okay, I'll be back with one.")) {
					stage = 10;
					Progression.progress++;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Just a Liquid Wisp from the Tavern. It's my favorite drink and I really miss it up here.");
				break;
			}
		}
		else stage = 0;	
	}
}