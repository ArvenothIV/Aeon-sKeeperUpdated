using UnityEngine;
using System.Collections;

public class ProgIntDesCav : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	public WorldButtonInteraction WBI;
	
	private string sandStr = "✖";
	private string orbStr = "✖";
	
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		WBI = GameObject.Find("hourglasssandP").GetComponent<WorldButtonInteraction>();
		
		if (Progression.previousScene == "Desert") {
			player.cc.transform.position = new Vector3(0f, 0f, -1f);
		}
		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	
	void OnGUI(){
		if(WBI.clicked && Progression.hasSands == false){
			if(GUI.Button (new Rect (Screen.width/2f - (WBI.messageLength*3.5f)/2f,
			   Screen.height/2.8f - 25, WBI.messageLength*3.5f, WBI.messageHeight), "You scoop a bit of the sands into your inventory in what feels like an eternity.")){
				Progression.hasSands = true;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
		switch(Progression.progress){
			case 18:
				if(Progression.hasSands){sandStr = "✔";}
				if(Progression.dungeonCompleted){orbStr = "✔";}
				QuestBar.task = "Gather items for the ritual: Sands: " + sandStr + ", Orb: " + orbStr + ", Herbs: " + Progression.herbsCollected + "/20.";
				break;
		}
	}
}
