using UnityEngine;
using System.Collections;

public class ProgressInteractionHome2 : MonoBehaviour {
	
	public playerController player;
	public FadeInAndOut fadeScript;
	
	private bool temp = true;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		if (Progression.previousScene == "Outsidehome3") {
			player.GetComponent<CharacterController>().transform.position = new Vector3(0f, 11f, -1f);
		}
		if (Progression.previousScene == "Tutorial1") {
			player.GetComponent<CharacterController>().transform.position = new Vector3(0f, 0.8f, -1f);
		}
		if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	
	
	void OnGUI () {
		switch(Progression.progress){
		case 7:
			QuestBar.task = "Your home is filling with water too! Hurry outside!";
			Progression.progress = 8;
			break;
		case 9:
			if(temp){
				foreach(GameObject flare in GameObject.FindGameObjectsWithTag("dreamflare")){
					Destroy(flare);
				}
				player.GetComponent<CharacterController>().transform.position = new Vector3(-8.4f, 6.1f, -1f);
				QuestBar.barHeight = Screen.height / 9f;
				QuestBar.title = "Seeking Answers:";
				QuestBar.task = "You knock a soft piece of metal to the floor. You pick it up and analyze it. It's the Blade of Absurdity!";
				Destroy (GameObject.Find ("Music"));
				temp = false;
			}
			if (GUI.Button (new Rect (Screen.width/2f - (9 *(Screen.width / 100f)/2f), Screen.height/2.8f - (8 *(Screen.height / 100f)/2f),
			                          9 *(Screen.width / 100f), 8 *(Screen.height / 100f)), "Next")){
				Progression.progress++;
				temp = true;
			}
			break; 
		case 10:
			QuestBar.barHeight = Screen.height / 9f;
			QuestBar.title = "Seeking Answers:";
			QuestBar.task = "Head to town to find a dream teller.";
			temp = false;
			break;
			
		}
	}
}
