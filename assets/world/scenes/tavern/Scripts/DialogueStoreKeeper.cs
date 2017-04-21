using UnityEngine;
using System.Collections;

public class DialogueStoreKeeper : MonoBehaviour {

	public WorldButtonInteraction npcScript;
	private PlayerInventory inven;
	private int stage;
	public float messageHeight, messageLength, fontSize;
	// Use this for initialization
	void Start () {
		npcScript = GameObject.Find ("StoreKeeper").GetComponent<WorldButtonInteraction>();
		inven = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
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
		
		if(npcScript.isTriggered == true){// && Progression.progress == 12){
			switch(stage){
			case 1:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Yes, I'd like a Liquid Wisp.")) {
					stage = 2;
				}
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "I need a room for the night.")) {
					stage = 5;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Hello Sir. Our prices are the fairest in the land. What would you like?");
				break;
			case 2:
				if(inven.currentGold >= 10){
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "Here you go. (Pay 10 gold)")) {
						stage = 3;
						inven.currentGold -= 10;
						Progression.hasDrink = true;
					}
				}
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "I don't have enough money.")) {
					stage = 10;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "A fine choice sir. That'll be 10 gold.");
				break;
			case 3:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "Do you have anything for a headache?")) {
					stage = 4;
				}
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "Yes. Thank you. Have a good eveing.")) {
					stage = 10;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Will that be all sir?");
				break;
			case 4:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 6f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 6f, messageHeight), "Thanks. (You stir all the BloodFairy wings into the drink)")) {                        
					stage = 10;
					Progression.hasDrink = false;
					Progression.hasDruggedDrink = true;
				}
				GUI.Box (new Rect (0, Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "In fact I do. Some crushed Bloodfairy wings should do the trick. Don't take too much \nor it'll knock you out for hours. Here, it's on the tavern.");
				break;
			case 5:
				if(inven.currentGold >= 150){
					if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 4f)/ 2f,
					                          Screen.height / 2f - messageHeight/2f, messageLength * 4f, messageHeight), "Here you go. (Pay 150 gold)")) {
						stage = 6;
						inven.currentGold -= 150;
						Progression.hasRentedRoom = true;
					}
				}
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f) / 2f,
				                          Screen.height / 2.8f - messageHeight/2f, messageLength * 5f, messageHeight), "I don't have enough money.")) {
					stage = 10;
				}
				GUI.Box (new Rect (0,Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "A room just opened up. It'll be 150 gold for the night.");
				break;
			case 6:
				if (GUI.Button (new Rect (Screen.width / 2f - (messageLength * 5f)/ 2f,
				                          Screen.height / 2f - messageHeight/2f, messageLength * 5f, messageHeight), "Yes. Good evening.")) {
					stage = 10;
				}
				GUI.Box (new Rect (0,Screen.height/3.5f - messageHeight/2f,
				                   Screen.width, messageHeight),
				         "Will that be all for today sir?");
				break;
			}
		}
		else stage = 0;	
	}
}
