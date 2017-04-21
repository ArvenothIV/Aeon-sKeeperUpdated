using UnityEngine;
using System.Collections;

public class DialogueBoyD : MonoBehaviour {

	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("BoyD").GetComponent<WorldButtonInteraction>();
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
		
		if(npcScript.isTriggered == true && Progression.progress == 17){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				    Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Next")) {
					stage = 20;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "We made it safely sir! The dream teller is just a ways into the desert.");
				break;
			}
		}
		else if(npcScript.isTriggered == true){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Hello.")) {
					stage = 20;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Hi.");
				break;
			}
		}
		else stage = 0;	
	}
}
