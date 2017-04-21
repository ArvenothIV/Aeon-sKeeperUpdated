using UnityEngine;
using System.Collections;

public class ProgressionInteractionDesert : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	private GameObject stairs;
	private Vector3 stairsStart;
	private Vector3 stairsEnd;
	
	private string sandStr = "✖";
	private string orbStr = "✖";
	
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		stairs = GameObject.Find ("StepsP");
		//===========for testing======
		if (Progression.previousScene == "Tutorial1") {
			player.cc.transform.position = new Vector3(-95f, 85f, -1f);
			Progression.progress = 18;
			Progression.dungeonCompleted = true;
			Progression.herbsCollected = 20;
			Progression.hasSands = true;
		}
		//==============================
		if (Progression.previousScene == "Town") {
			player.cc.transform.position = new Vector3(99f, -41f, -1f);
		}
		else if (Progression.previousScene == "DesertCavern") {
			player.cc.transform.position = new Vector3(-95f, 85f, -1f);
		}
		else if (Progression.previousScene == "Dungeon") {//DEMO
			player.cc.transform.position = new Vector3(14.89f, -42.92f, -1f);
		}
		else if (Progression.previousScene == "Desert") {//DEMO
			player.cc.transform.position = new Vector3(-95f, 85f, -1f);
		}
		else if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		stairsEnd = new Vector3(12.5f, -45f, -0.1f);
		stairsStart = new Vector3(12.5f, -45f, -10f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Progression.levers[0] == 1 &&
		   Progression.levers[1] == 2 &&
		   Progression.levers[2] == 8 &&
		   Progression.levers[3] == 0 &&
		   Progression.levers[4] == 8){
		  	stairs.transform.position = stairsEnd;
		 }
		else stairs.transform.position = stairsStart;
		
		switch(Progression.progress){
			case 17:
				QuestBar.task = "Find Aeon, the dream teller.";
				break;
			case 18:
				if(Progression.hasSands){sandStr = "✔";}
				if(Progression.dungeonCompleted){orbStr = "✔";}
				QuestBar.title = "The Ritual:";
				QuestBar.task = "Gather items for the ritual: Sands: " + sandStr + ", Orb: " + orbStr + ", Herbs: " + Progression.herbsCollected + "/20.";
				break;
			case 19:
				QuestBar.barHeight = Screen.height/9f;
				QuestBar.title = "The Ritual:";
				QuestBar.task = "Enter the Gazebo to complete ritual.";
				break;
		}
	}
}