using UnityEngine;
using System.Collections;

public class ProgressInteractionBunnyIsle: MonoBehaviour {
	public playerController player;
	public FadeInAndOut fadeScript;
	
	private PlayerInventory inven;
	
	public WorldButtonInteraction chestScriptL;
	public WorldButtonInteraction chestScriptU;
	
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		chestScriptL = GameObject.Find ("ChestLocked").GetComponent<WorldButtonInteraction>();
		chestScriptU = GameObject.Find ("ChestUnlocked").GetComponent<WorldButtonInteraction>();
		inven = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
		
		if (Progression.previousScene == "Outsidehome3"||Progression.previousScene == "Desert") {
			player.cc.transform.position = new Vector3(-40f, -8f, -1f);
			if(Progression.previousScene == "Desert"){
				Progression.levers[0] = 1;
				Progression.levers[1] = 2;
				Progression.levers[2] = 8;
				Progression.levers[3] = 0;
				Progression.levers[4] = 8;
			}
		}
		else if (Progression.previousScene == "Dungeon") {
			player.cc.transform.position = new Vector3(54f, -4f, -1f);
		}
		else if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		if(Progression.chestUnlocked){
			GameObject.Find("ChestLocked").transform.position = new Vector3(48.78f, 4.02f, 10f);
			GameObject.Find("ChestUnlocked").transform.position = new Vector3(48.78f, 4.02f, -0.5f);
		}
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(chestScriptL.clicked && !Progression.chestUnlocked){
			if(inven.currentGold >= 12808){
				if(GUI.Button (new Rect (Screen.width/2f - (chestScriptL.messageLength*6.5f)/2f,
				                         Screen.height/2.8f - 25, chestScriptL.messageLength*6.5f, chestScriptL.messageHeight), "Your payment unlocks the chest. Peering inside, you see a steep flight of stairs.")){
					Progression.chestUnlocked = true;
					GameObject.Find("ChestLocked").transform.position = new Vector3(48.78f, 4.02f, 10f);
					GameObject.Find("ChestUnlocked").transform.position = new Vector3(48.78f, 4.02f, -0.5f);
					inven.currentGold -= 12808;
				}
			}
			else{
				if(GUI.Button (new Rect (Screen.width/2f - (chestScriptL.messageLength*1.5f)/2f,
				                         Screen.height/2.8f - 25, chestScriptL.messageLength*1.5f, chestScriptL.messageHeight), "You don't have enough gold.")){
					chestScriptL.clicked = false;
				}
			}
		}		
	}
}
