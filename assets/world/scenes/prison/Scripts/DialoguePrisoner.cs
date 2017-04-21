using UnityEngine;
using System.Collections;

public class DialoguePrisoner : MonoBehaviour {

	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("friend").GetComponent<WorldButtonInteraction>();
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
		
		if(npcScript.isTriggered && Progression.progress == 13){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Your friend asked me to break you out of prison.")) {
					stage = 2;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Um... Hello.");
				break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "I'll steal the key.")) {
					stage = 3;
				}
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "I don't have one.")) {
					stage = 4;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Oh! That's great! What's your plan?");
				break;
			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 3f) / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 3f, messageHeight), "Okay, I guess I don't have a plan.")) {
					stage = 4;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Keys!? Ha! These are magical locks that only unlock after the sentence is up.");
				break;
			case 4:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "And how should I do that exactly?")) {
					stage = 5;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "That's fine, I have one. You simply need to expose the outside wall of my cell to intense heat until it crumbles.");
				break;
			case 5:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 5f, messageHeight), "I'll try my best.")) {
					stage = 6;
				}
				GUI.Box (new Rect (0,Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Just moisten the wall with vingear and place a burning pot of charcoal beneath.");
				break;
			case 6:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 5f, messageHeight), "Next")) {
					stage = 7;
					Progression.progress++;
				}
				GUI.Box (new Rect (0,Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Oh, and one more thing. You'll need to distract the jailer somehow. Can't just let him watch the escape.");
				break;
			}
		}
		/*if (npcScript.isTriggered && Progression.progress == 15) {
			switch(stage){
			case 7:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Will do.")) {
					stage = 8;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "You got it all! Use it on the wall outside so I can get out!");
				break;
			}
				
		}*/
		else stage = 0;	
	}
}
