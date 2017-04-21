using UnityEngine;
using System.Collections;

public class DialogueAeon : MonoBehaviour {
	
	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("Aeon").GetComponent<WorldButtonInteraction>();
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
					    Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Hi, my name is...")) {
						stage = 2;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Greetings.");
					break;
				case 2:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "(Tell Aeon your dream)")) {
						stage = 3;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "I know who you are and why you are here. It took you many realities to \nfinally make it. I am glad. Now, tell me your dream.");
					break;
				case 3:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					    Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "So the world is ending!?")) {
						stage = 4;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "I've feared the coming of this day. Your dream is not merely illusion but rather a truth.");
					break;
				case 4:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "How do you propose we do that?")) {
						stage = 5;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Indeed. Luckily it can be stopped. Pieces of life can be altered to prolong their existences.");
					break;
				case 5:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "It was and I guess that makes sense.")) {
						stage = 6;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "In your vision, life on Earth was extinguished through flood, was it not? \nSimply raising the land beneath us will counter that destruction.");
					break;
				case 6:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Go on.")) {
						stage = 7;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Good. In the past, I came across a ritual capable of imbuing a beings essence\n into an object to make said object disobey its predetermined laws.");
					break;
				case 7:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "What do we need for this ritual?")) {
						stage = 8;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "This ritual will allow the permenant raising of these surrounding lands, \nsaving your family, friends, neighbors and any other loved ones.");
					break;
				case 8:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Where can I find these items?")) {
						stage = 9;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "We'll need the sands of a sacred hourglass, the Orb of Transfusion, and roughly 20 somnum tenebris leaves.");
					break;
				case 9:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Well, I'll see what I can get.")) {
						stage = 20;
						Progression.progress = 18;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "The sands will likely be in the desert. I know that trolls are \nquite fond of the leaves and I'm sure you can find the orb on your own.");
					break;
			}
		}
		else if(npcScript.isTriggered == true && Progression.progress == 18 && Progression.hasSands && Progression.herbsCollected >= 20 && Progression.dungeonCompleted){
			switch(stage){
				case 1:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "I have. Here's everything.")) {
						stage = 2;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Have you found all the ingredients for the ritual yet?");
					break;
				case 2:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Yes. I'm ready.")) {
						stage = 3;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Shall we go and begin the ritual?");
					break;
				case 3:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Next")) {
						stage = 20;
						Progression.progress = 19;
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Head to the gazebo.");
					break;
			}
		}
		else if(npcScript.isTriggered == true && Progression.progress == 18){
			switch(stage){
				case 1:
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "No, not yet.")) {
						stage = 20;
						
					}
					GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
					                   Screen.width, messageHeight),
					         "Have you found all the ingredients for the ritual yet?");
					break;
			}
		}
		else stage = 0;	
	}
}