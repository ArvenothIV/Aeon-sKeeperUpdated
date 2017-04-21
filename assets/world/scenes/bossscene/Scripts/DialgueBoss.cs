using UnityEngine;
using System.Collections;
//Woman dialogue for alternate route to town in outsideHome3
public class DialgueBoss : MonoBehaviour {
	
	public WorldButtonInteraction npcScript;
	public BossAI aBoss;

	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("Boss").GetComponent<WorldButtonInteraction>();
		stage = 0;
		aBoss= GameObject.Find ("Boss").GetComponent<BossAI>();
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
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "Who are you?")) {
										stage = 2;
										
								}
								GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I've been waiting.");
								break;
			case 2:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "This can't be...")) {
					stage = 3;

				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I'm the true form of Aeon.");
				break;

			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "You don't know what's right!")) {
					stage = 4;

				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I have come to stop you from saving the world's set demise. I am the Guardian \nof the land. It is for me to decide what is right.");
				break;
			case 4:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "My dream...")) {
					stage = 5;

				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "Who are you to decide?");
				break;
			case 5:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "  ...  ")) {
					stage = 6;

				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "You mean the one I made you have?");
				break;
			case 6:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "  ...  ")) {
					stage = 7;

				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "Thank you for bringing me the three keys...\n thank you for freeing my friend... thank you for the supplies...");
				break;

			case 7:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight),  "I will stop you.")) {
					stage = 8;

				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "You can not stop me now. The world is doomed.");
				break;

			case 8:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Start Final Fight.")) {
					stage = 9;
					aBoss.startFight = true;
					QuestBar.barHeight = Screen.height / 9f;
					QuestBar.title = "Boss";
					QuestBar.task = "Defeat Aeon.";
					Destroy (this.GetComponent("WorldButtonInteraction"));
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 4f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "You fool.");
				break;
						
			
						}
				}
		else stage = 0;	
	}
}