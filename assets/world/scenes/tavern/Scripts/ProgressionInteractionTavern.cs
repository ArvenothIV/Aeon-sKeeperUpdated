using UnityEngine;
using System.Collections;

public class ProgressionInteractionTavern : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	public WorldButtonInteraction stairScript;
	public WorldButtonInteraction stairTopScript;
	public WorldButtonInteraction doorScript;
	public WorldButtonInteraction potScript;
	
	private string pot = "✖";
	private string vinegare = "✖";
	private string charcoal = "✖";
	private string drugged = "✖";
	
	private bool temp = true;
	private float timer = 0f;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		stairScript = GameObject.Find ("stairs").GetComponent<WorldButtonInteraction>();
		stairTopScript = GameObject.Find ("stairstop").GetComponent<WorldButtonInteraction>();
		doorScript = GameObject.Find ("doorPot").GetComponent<WorldButtonInteraction>();
		potScript = GameObject.Find ("Pot").GetComponent<WorldButtonInteraction>();
		
		if (Progression.previousScene == "Town") {
			player.cc.transform.position = new Vector3(0f, 0f, -1f);
		}
		else if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	
	// Update is called once per frame
	void OnGUI () {
		//Stairs
		if(stairScript.clicked || stairTopScript.clicked){
			if(temp){
				fadeScript.fade = true;
				fadeScript.fadingIn = true;
				fadeScript.bothFades = true;
				temp = false;
			}
			if(fadeScript.fadingIn == false){
				if(timer <= 10f){
					if(stairScript.clicked){
						player.cc.transform.position = new Vector3(-19f, 48f, -1f);
					}
					else player.cc.transform.position = new Vector3(-19.5f, 0f, -1f);
					fadeScript.fadingOut = true;
					fadeScript.bothFades = false;
				}
				if(timer <= 0f){
					timer = 600f;
				}
				timer--;
			}
			if(fadeScript.fade == false){
				temp = true;
				timer = 0f;
			}
		}
		//Door
		if(doorScript.clicked){
			if(!Progression.hasRentedRoom){
				if(GUI.Button (new Rect (Screen.width/2f - (doorScript.messageLength*2.5f)/2f,
				                         Screen.height/2.8f - 25, doorScript.messageLength*2.5f, doorScript.messageHeight), "You need to pay for a room.")){
					doorScript.clicked = false;
				}
			}
			else{
				if(GUI.Button (new Rect (Screen.width/2f - (doorScript.messageLength*2.2f)/2f,
				                         Screen.height/2.8f - 25, doorScript.messageLength*2.2f, doorScript.messageHeight), "You unlock your room.")){
					doorScript.clicked = false;
					Destroy(GameObject.FindGameObjectWithTag("TavernDoor"));
				}
			}
		}
		//Pot
		if(potScript.clicked){
			if(!Progression.hasPot){
				if(GUI.Button (new Rect (Screen.width/2f - (potScript.messageLength*2.2f)/2f,
				                         Screen.height/2.8f - 25, potScript.messageLength*2.2f, potScript.messageHeight), "You take the pot.")){
					potScript.clicked = false;
					Progression.hasPot = true;
				}
			}
			else{
				if(GUI.Button (new Rect (Screen.width/2f - (potScript.messageLength*2.2f)/2f,
				                         Screen.height/2.8f - 25, potScript.messageLength*2.2f, potScript.messageHeight), "You already have a pot.")){
					potScript.clicked = false;
				}
			}
		}
	}
	void Update () {
		switch(Progression.progress){
			case 14:
				if(Progression.hasPot){pot = "✔";}
				if(Progression.hasVinegar){vinegare = "✔";}
				if(Progression.hasCharcoal){charcoal = "✔";}
				if(Progression.hasPot){pot = "✔";}
				if(Progression.hasDruggedJailer){drugged = "✔";}
				QuestBar.task = "Break the boys friend out of prison. Collect: Pot " + pot + " ,Vinegar " + vinegare + " ,Charcoal " + charcoal+". Drug the jailer " + drugged + ".";
				break;
			case 15:
				if(Progression.hasPot){pot = "✔";}
				if(Progression.hasVinegar){vinegare = "✔";}
				if(Progression.hasCharcoal){charcoal = "✔";}
				if(Progression.hasPot){pot = "✔";}
				if(Progression.hasDruggedJailer){drugged = "✔";}
				QuestBar.task = "Break the boys friend out of prison. Collect: Pot " + pot + " ,Vinegar " + vinegare + " ,Charcoal " + charcoal+". Drug the jailer " + drugged + ".";
				break;
		}
	}
}
