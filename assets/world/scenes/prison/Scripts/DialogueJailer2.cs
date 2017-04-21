using UnityEngine;
using System.Collections;

public class DialogueJailer2 : MonoBehaviour {

	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("Jailer").GetComponent<WorldButtonInteraction>();
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
		
		if(npcScript.isTriggered == true && Progression.hasDrink){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Yes. Hear it is.")) {
					stage = 2;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Do you have my drink?");
				break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "*Give jailer an evil look and run away*")) {
					stage = 10;
				}
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "Thanks, Goodbye.")) {
					stage = 10;
					Progression.hasVinegar = true;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Here's the vinegar you asked for.");
				break;

			}
		}
		else if(npcScript.isTriggered == true && Progression.hasDruggedDrink){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Yes. Hear it is.")) {
					stage = 2;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Do you have my drink?");
				break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "We still had a deal.")) {
					stage = 3;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Hmmm... It's not as good as I remembered.");
				break;
			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "Thanks. It works out better this way.")) {
					stage = 10;
					Progression.hasVinegar = true;
					Progression.hasDruggedJailer = true;

					Vector3 temp = GameObject.Find ("Jailer").transform.position;
					temp.z = 10f; 
					GameObject.Find ("Jailer").transform.position = temp;

					Vector3 temp2 = GameObject.Find ("JailerDown").transform.position;
					temp2.z = -0.6f; 
					GameObject.Find ("JailerDown").transform.position = temp2;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Very well. Here's your bottle of vinegar. You know, you could've just bought some at the same tavern.");
				break;	
			}
		}
		else if(npcScript.isTriggered == true){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "What drink?")) {
					stage = 2;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Do you have my drink?");
				break;
			}
		} 
		else stage = 0;	
	}
}