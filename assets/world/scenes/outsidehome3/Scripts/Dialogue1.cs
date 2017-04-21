using UnityEngine;
using System.Collections;
//Mercenary dialogue blocking the road in outsideHome3
public class Dialogue1 : MonoBehaviour {
	
	public WorldButtonInteraction npcScript;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("NPC_Mercenary").GetComponent<WorldButtonInteraction>();
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
		
		if(npcScript.isTriggered == true){
			switch(stage){
				case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
						stage = 2;
					}
					
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				         Screen.width, messageHeight),
				         "I am the soldier who guards this path. None shall pass.");
					break;
				case 2:
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
					   	Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
						stage = 3;
					}
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
					 		Screen.width, messageHeight),
				         	"Why are you still here? Would you like to here a tale?");
				    break;
				case 3:
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
						stage = 4;
					}
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         			"A quiet one I see... Well let me tell you the tail of the Great Guardians.");
					
					break;
				case 4:
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
						stage = 5;
					}
					GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "A long time ago... in a Galaxy far away... there were four Guardians....");
					break;
				case 5:
					if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 6;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "With the power of their 'Right-Click Button' they each had a distinct ability...");
				
				break;
			case 6:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 7;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "The WARRIOR possed the ability to HEAL during battle, at the cost of 40 MANA....");
				
				break;
			case 7:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 8;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "The MAGE possed the ability to DAMAGE ENEMIES AROUND HER with magic, at the cost of 40 MANA....");
				
				break;
			case 8:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 9;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "The THEIF possed the ability to DAMAGE ENEMIES AROUND HIM with knives, at the cost of 40 MANA....");
				
				break;
			case 9:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "Next")) {
					stage = 10;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "The HUNTER possed the ability to CALM ENEMIES attacking him, at the cost of 40 MANA....");
				
				break;

			case 10:
				if (GUI.Button (new Rect (Screen.width / 2f - messageLength / 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength, messageHeight), "End")) {
					stage = 11;
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "With their powers combined they summoned Captain Planet...wait.. that doesn't sound right.");
				
				break;
			}
		}
		else stage = 0;	
	}
}
