using UnityEngine;
using System.Collections;

public class ProgressionInteractionDungeon : MonoBehaviour {
	
	public playerController player;
	public FadeInAndOut fadeScript;
	private int wavecount = 5;
	public GameObject Enemy;
	public GameObject Goblin;
	public GameObject EvilBeast;
	public GameObject UndeadWizard;
	
	private string sandStr = "✖";
	private string orbStr = "✖";
	
	public WorldButtonInteraction transfusion;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		
		transfusion = GameObject.Find ("OrbTransfusion").GetComponent<WorldButtonInteraction>();
		
		player.cc.transform.position = new Vector3(0f, 0f, -1f);

		if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		Progression.killCount = 0;
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
	}
	
	void OnGUI(){
		if(transfusion.clicked && !Progression.dungeonCompleted){
			if(GUI.Button (new Rect (Screen.width/2f - (transfusion.messageLength*6.5f)/2f,
			   Screen.height/2.8f - 25, transfusion.messageLength*6.5f, transfusion.messageHeight), "You take the sphere of whirling blood.")){
			   Progression.dungeonCompleted = true;
			   transfusion.clicked = false;		   
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
	if(wavecount == 5){
		if(Progression.killCount == 10)
		{
			Progression.killCount = 0;
			Destroy (GameObject.Find ("Orb1"));
				wavecount = 4;
				GameObject enemyClone1 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(1,1,0), Quaternion.identity);
				GameObject enemyClone2 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(1,-1,0), Quaternion.identity);
				GameObject enemyClone3 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(-1,1,0), Quaternion.identity);
				GameObject enemyClone4 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(1,0,0), Quaternion.identity);
				GameObject enemyClone5 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(0,1,0), Quaternion.identity);
				GameObject enemyClone6 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(-1,0,0), Quaternion.identity);
				GameObject enemyClone7 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(0,-1,0), Quaternion.identity);
				GameObject enemyClone8 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(-2,1,0), Quaternion.identity);
				GameObject enemyClone9 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(1,-2,0), Quaternion.identity);
				GameObject enemyClone10 = 
					(GameObject)Instantiate(Enemy, transform.position + new Vector3(2,-2,0), Quaternion.identity);
		}
	}
	else if(wavecount == 4){
			if(Progression.killCount == 10)
			{
				Progression.killCount = 0;
				Destroy (GameObject.Find ("Orb2"));
				GameObject enemyClone1 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(1,1,0), Quaternion.identity);
				GameObject enemyClone2 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(1,-1,0), Quaternion.identity);
				GameObject enemyClone3 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(-1,1,0), Quaternion.identity);
				GameObject enemyClone4 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(1,0,0), Quaternion.identity);
				GameObject enemyClone5 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(0,1,0), Quaternion.identity);
				GameObject enemyClone6 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(-1,0,0), Quaternion.identity);
				GameObject enemyClone7 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(0,-1,0), Quaternion.identity);
				GameObject enemyClone8 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(-2,1,0), Quaternion.identity);
				GameObject enemyClone9 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(1,-2,0), Quaternion.identity);
				GameObject enemyClone10 = 
					(GameObject)Instantiate(Goblin, transform.position + new Vector3(2,-2,0), Quaternion.identity);
				wavecount = 3;
			}
	}
	else if(wavecount == 3){
			if(Progression.killCount == 10)
			{
				Progression.killCount = 0;
				Destroy (GameObject.Find ("Orb3"));
				GameObject enemyClone1 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(1,1,0), Quaternion.identity);
				GameObject enemyClone2 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(1,-1,0), Quaternion.identity);
				GameObject enemyClone3 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(-1,1,0), Quaternion.identity);
				GameObject enemyClone4 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(1,0,0), Quaternion.identity);
				GameObject enemyClone5 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(0,1,0), Quaternion.identity);
				GameObject enemyClone6 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(-1,0,0), Quaternion.identity);
				GameObject enemyClone7 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(0,-1,0), Quaternion.identity);
				GameObject enemyClone8 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(-2,1,0), Quaternion.identity);
				GameObject enemyClone9 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(1,-2,0), Quaternion.identity);
				GameObject enemyClone10 = 
					(GameObject)Instantiate(EvilBeast, transform.position + new Vector3(2,-2,0), Quaternion.identity);
				wavecount = 2;

			}
	}
	else if(wavecount == 2){
			if(Progression.killCount == 10)
			{
				Progression.killCount = 0;
				Destroy (GameObject.Find ("Orb4"));
				GameObject enemyClone1 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(1,1,0), Quaternion.identity);
				GameObject enemyClone2 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(1,-1,0), Quaternion.identity);
				GameObject enemyClone3 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(-1,1,0), Quaternion.identity);
				GameObject enemyClone4 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(1,0,0), Quaternion.identity);
				GameObject enemyClone5 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(0,1,0), Quaternion.identity);
				GameObject enemyClone6 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(-1,0,0), Quaternion.identity);
				GameObject enemyClone7 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(0,-1,0), Quaternion.identity);
				GameObject enemyClone8 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(-2,1,0), Quaternion.identity);
				GameObject enemyClone9 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(1,-2,0), Quaternion.identity);
				GameObject enemyClone10 = 
					(GameObject)Instantiate(UndeadWizard, transform.position + new Vector3(2,-2,0), Quaternion.identity);
				wavecount = 1;

			}	
	}
	else if(wavecount == 1){
			if(Progression.killCount == 10)
			{
				Progression.killCount = 0;
				Destroy (GameObject.Find ("Orb5"));
				wavecount = 0;

			}
	}
	else{
		GameObject.Find ("OrbTransfusion").transform.position = new Vector3( 0f, 0f, -0.5f);	
	}
 }
}
