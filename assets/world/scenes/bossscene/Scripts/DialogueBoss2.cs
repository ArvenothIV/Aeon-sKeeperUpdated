using UnityEngine;
using System.Collections;
//Woman dialogue for alternate route to town in outsideHome3
public class DialogueBoss2 : MonoBehaviour {
	
	public WorldButtonInteraction npcScript;

	
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("Down_3").GetComponent<WorldButtonInteraction>();
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
		
		if (npcScript.isTriggered == true) {
			switch (stage) {
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "You left me no choice.")) {
					stage = 2;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "You have defeated me....");
				break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "What curse?")) {
					stage = 3;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I do not envy you. For now I am released of this curse.");
				break;
				
			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "What do you mean?")) {
					stage = 4;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I am the Guardian of the land, but not by choice.");
				break;
			case 4:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "I don't understand")) {
					stage = 5;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "There was a tale that Guardians were chosen, this is not true. The title of Guardian is earned.");
				break;
			case 5:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "  ...  ")) {
					stage = 6;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "The reason I brought you here is to remove this curse, to help me leave");
				break;
			case 6:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "  ...  ")) {
					stage = 7;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I was going to do so by destroying this world.");
				break;
				
			case 7:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "...")) {
					stage = 8;
					
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "But you let me free by other means.");
				break;
				
			case 8:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "But... you're Aeon...")) {
					stage = 9;
					Progression.progress = 20;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "You are the next Guardian, and for those who follow as well. Your children and your \nchildren's children will all have this title. Thank you... Aeon. ");
				break;
				
				
			}
		}
		else stage = 0;	
	}
}