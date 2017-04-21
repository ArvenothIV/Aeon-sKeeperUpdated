using UnityEngine;
using System.Collections;

public class DialogueBoy : MonoBehaviour {

	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("Boy").GetComponent<WorldButtonInteraction>();
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
		
		if (npcScript.isTriggered == true && Progression.progress == 12) {
						switch (stage) {
						case 1:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f) / 2f,
				                Screen.height / 2f - messageHeight / 2f, messageLength * 6f, messageHeight), "Do you know where to find the dream teller?")) {
										stage = 2;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "What can I do for you sir?");
								break;
						case 2:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f) / 2f,
				                Screen.height / 2f - messageHeight / 2f, messageLength * 4f, messageHeight), "And you'll take me to a dream teller?")) {
										stage = 3;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "I can help you if you can help me.");
								break;
						case 3:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 3f) / 2f,
				                          Screen.height / 2f - messageHeight / 2f, messageLength * 3f, messageHeight), "Why? Was he framed?")) {
										stage = 4;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "Yes. Just break my friend out of jail first.");
								break;
						case 4:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight / 2f, messageLength * 5f, messageHeight), "You're on your own, I'll find someone else.")) {
										stage = 10;
								}
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f) / 2f,
				                          Screen.height / 2f - messageHeight / 2f, messageLength * 4f, messageHeight), "Fine, I'll help. Where's the prison.")) {
										stage = 5;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "Err, yes, he was framed... You sure ask a lot of questions sir.");
								break;
						case 5:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2f - messageHeight / 2f, messageLength * 5f, messageHeight), "Okay, I'll see what I can do.")) {
										stage = 10;
										Progression.progress++;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "It's to the North-West, outside of town. He's in the East cell.");
								break;
						}
				} else if (npcScript.isTriggered == true && Progression.progress == 16) {
						switch (stage) {
						case 1:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f) / 2f,
					                          Screen.height / 2f - messageHeight / 2f, messageLength * 6f, messageHeight), "Okay, I'll see you there.")) {
										stage = 2;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
					                   Screen.width, messageHeight),
					         "Okay, time to live up to my end of the bargain. Meet me to the South-West of town. I have a boat there.");
								break;
						case 2:
								if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f) / 2f,
				    Screen.height / 2f - messageHeight / 2f, messageLength * 6f, messageHeight), "Yes. Here. (Hand over Blade of Absurdity)")) {
										stage = 20;
										Progression.progress = 17;
								}
								GUI.Box (new Rect (0, Screen.height / 3.5f - messageHeight / 2f,
				                   Screen.width, messageHeight),
				         "Oh, and one more thing sir... It's dangerous to go along. Do you have \nsome sort of weapon I can have so I can defend myself?");
								break;
						}
				} 
				else if (Progression.progress == 17) {
					Vector3 temp = GameObject.Find ("boyBoat").transform.position;
					temp.z = -1f; 
					GameObject.Find ("boyBoat").transform.position = temp;
				}
		else stage = 0;	
	}
}
