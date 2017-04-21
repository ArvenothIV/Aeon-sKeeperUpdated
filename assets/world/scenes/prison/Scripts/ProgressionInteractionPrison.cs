using UnityEngine;
using System.Collections;

public class ProgressionInteractionPrison : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	private string pot = "✖";
	private string vinegare = "✖";
	private string charcoal = "✖";
	private string drugged = "✖";
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		if (Progression.previousScene == "Town") {
			player.cc.transform.position = new Vector3(-1.5f, 0f, -1f);
			if(Progression.progress==16){
				Vector3 temp = GameObject.Find ("friend").transform.position;
				temp.z = 10f; 
				GameObject.Find ("friend").transform.position = temp;
			}
		}
		else if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}

		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	// Update is called once per frame
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
