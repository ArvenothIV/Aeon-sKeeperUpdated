using UnityEngine;
using System.Collections;

public class ProgressionInteractionTown : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	public WorldButtonInteraction prisonWallScript;
	
	private string pot = "✖";
	private string vinegare = "✖";
	private string charcoal = "✖";
	private string drugged = "✖";
	
	private string sandStr = "✖";
	private string orbStr = "✖";
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		prisonWallScript = GameObject.Find ("towerExplode").GetComponent<WorldButtonInteraction>();
		
		if (Progression.previousScene == "Outsidehome3") {
						player.cc.transform.position = new Vector3 (-51.5f, -81f, -1f);
						if (Progression.progress == 12) {
								QuestBar.task = "Look for answers around town.";
						}
				} 
		else if (Progression.previousScene == "Town") {
				if(player.transform.position.y>120){
				player.cc.transform.position = new Vector3(1, -3.3f, -1f);
			}
				else{
				player.cc.transform.position = new Vector3(-78.67f, 144.58f, -1f);
			}
		}
		else if (Progression.previousScene == "CavePuzzle") {
			player.cc.transform.position = new Vector3(-58.34f, 182.62f, -1f);
		}
		else if (Progression.previousScene == "Prison") {
			player.cc.transform.position = new Vector3(-74f, 163f, -1f);
		}
		else if (Progression.previousScene == "Tavern") {
			player.cc.transform.position = new Vector3(-3f, 4.5f, -1f);
		}
		else if (Progression.previousScene == "Desert") {
			player.cc.transform.position = new Vector3(-157f, -20f, -1f);
		}
		else if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		if(Progression.progress == 18){
			Progression.reHerb = true;
		}
	}
	
	void OnGUI(){
		if(prisonWallScript.clicked && Progression.progress == 15){
			if(Progression.hasCharcoal && Progression.hasDruggedJailer && Progression.hasVinegar && Progression.hasPot){
				if(GUI.Button (new Rect (Screen.width/2f - (prisonWallScript.messageLength*8f)/2f,
				                         Screen.height/2.8f - 25, prisonWallScript.messageLength*8f, prisonWallScript.messageHeight), "You follow the process exactly and after a long time the\n prison wall loosens and crumbles, freeing the prisoner.")){
					prisonWallScript.clicked = false;
					Progression.progress++;
				}
			}
			else{
				if(GUI.Button (new Rect (Screen.width/2f - (prisonWallScript.messageLength*2.2f)/2f,
				                         Screen.height/2.8f - 25, prisonWallScript.messageLength*2.2f, prisonWallScript.messageHeight), "There's more you need to do first.")){
					prisonWallScript.clicked = false;
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		switch(Progression.progress){
			case 13:
				QuestBar.task = "Head to the prison outside of town to the North-West.";
				break;
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
			case 16:
				QuestBar.task = "Return to the boy so he can lead you to the dream teller.";
				break;
			case 17:
				QuestBar.task = "Head to the boys boat South-West of town.";
				break;
			case 18:
				if(Progression.hasSands){sandStr = "✔";}
				if(Progression.dungeonCompleted){orbStr = "✔";}
				QuestBar.task = "Gather items for the ritual: Sands: " + sandStr + ", Orb: " + orbStr + ", Herbs: " + Progression.herbsCollected + "/20.";
				break;
		}
		if(Progression.reHerb){
			foreach(GameObject keyEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				if(keyEnemy.name == "Troll_Herb")
				{
					keyEnemy.GetComponent<MeleeEnemyAI>().drops[9] = 50;
				}
			}
			Progression.reHerb = false;
		}
	}
}
