using UnityEngine;
using System.Collections;

public class ProgressionInteractionCavePuzzle : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	public WorldButtonInteraction fireScript;
	
	private string pot = "✖";
	private string vinegare = "✖";
	private string charcoal = "✖";
	private string drugged = "✖";
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		fireScript = GameObject.Find ("Campfire").GetComponent<WorldButtonInteraction>();
		
		if (Progression.previousScene == "Outsidehome3") {
			player.cc.transform.position = new Vector3(0f, 0f, -1f);
		}
		else if (Progression.previousScene == "Town") {
			player.cc.transform.position = new Vector3(21.52f, 21.54f, -1f);
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
		if(fireScript.clicked){
			if(!Progression.hasCharcoal){
				if(GUI.Button (new Rect (Screen.width/2f - (fireScript.messageLength*2.2f)/2f,
			       Screen.height/2.8f - 25, fireScript.messageLength*2.2f, fireScript.messageHeight), "Take charcoal and a torch.")){
					fireScript.clicked = false;
					Progression.hasCharcoal = true;
				}
			}
			else{
				if(GUI.Button (new Rect (Screen.width/2f - (fireScript.messageLength*2.5f)/2f,
				                         Screen.height/2.8f - 25, fireScript.messageLength*2.5f, fireScript.messageHeight), "I don't need anything else here.")){
					fireScript.clicked = false;
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

