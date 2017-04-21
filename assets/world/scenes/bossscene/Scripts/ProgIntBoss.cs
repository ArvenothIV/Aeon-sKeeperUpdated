using UnityEngine;
using System.Collections;

public class ProgIntBoss : MonoBehaviour {
	
	public playerController player;
	public FadeInAndOut fadeScript;
	public GameObject inventory;
	private PlayerInventory playerInventory;
	
	private bool firstPass = true;
	
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventory = inventory.GetComponent<PlayerInventory>();
		
		if (Progression.previousScene == "Desert") {
			player.cc.transform.position = new Vector3(0f, -6f, -1f);
		}
		
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		QuestBar.barHeight = Screen.height / 9f;
		QuestBar.title = "???";
		QuestBar.task = "Talk to mysterious figure.";
	}
	
	// Update is called once per frame
	void Update () {
		if(Progression.progress == 20)
		{
			playerInventory.generation++;
			Application.LoadLevel("Tutorial1");
			Progression.progress = 0;
			player.cc.transform.position = new Vector3 (1.744855f, 30f, -1f);
			//increment generation count
			QuestBar.title = "Dream:";
			QuestBar.task = "This is the quest bar. It will guide you throughout your journey. Press 'Q twice to untoggle and toggle it.";
			/*if(firstPass){
				firstPass = false;
				Destroy(GameObject.Find("ScriptEmptyDontDestroy"));
				GameObject.Find("Colorable").GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
				fadeScript.fade = true;
				fadeScript.fadingIn = true;
				fadeScript.bothFades = true;
				GameObject.Find("Title").transform.position = new Vector3(GameObject.Find("Camera").transform.position.x,GameObject.Find("Camera").transform.position.y,-5.6f);
			}*/


		}
	}
}
