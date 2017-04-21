using UnityEngine;
using System.Collections;

public class ProgressionInteractionCave4 : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		if (Progression.previousScene == "Outsidehome3") {
			player.GetComponent<CharacterController>().transform.position = new Vector3(-18f, 10f, -1f);
		}
		if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		Progression.reKey = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Progression.progress == 11){
			QuestBar.task = "Find the keys to unlock the gate. " + Progression.keysFound + "/3 keys found.";
			if(Progression.keysFound == 2 && Progression.reKey){
				foreach(GameObject keyEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
				{
					if(keyEnemy.name == "Enemy_3Head_Key")
					{
						keyEnemy.GetComponent<MeleeEnemyAI>().drops[6] = 8;
					}
				}
				Progression.reKey = false;
			}
			if(Progression.keysFound == 3){
				foreach(GameObject keyEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
				{
					if(keyEnemy.name == "Enemy_3Head_Key")
					{
						keyEnemy.GetComponent<MeleeEnemyAI>().drops[6] = 0;
					}
				}
				Progression.keysFound = 0;
				Progression.progress++;
			}
		}
	}
}
