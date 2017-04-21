using UnityEngine;
using System.Collections;

public class ProgressInteractionOutsideHome3 : MonoBehaviour {

	public playerController player;
	public FadeInAndOut fadeScript;
	
	public WorldButtonInteraction treeCut;
	public float messageHeight, messageLength, fontSize;
	private bool temp = true;
	private bool clicked = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		fadeScript = GameObject.Find ("Colorable").GetComponent<FadeInAndOut>();
		treeCut = GameObject.Find ("Treechete").GetComponent<WorldButtonInteraction>();
		messageHeight = 68;
		messageLength = 68;
		fontSize = 30;
		if (Progression.previousScene == "makePlayer") {
			player.GetComponent<CharacterController>().transform.position = Progression.charPos;
		}
		if (Progression.previousScene == "Home2") {
			player.cc.transform.position = new Vector3(-3f, -8.5f, -1f);
		}
		if (Progression.previousScene == "Cave4") {
			player.cc.transform.position = new Vector3(42f, -77f, -1f);
		}
		if (Progression.previousScene == "House5") {
			player.cc.transform.position = new Vector3(33.7f, -4f, -1f);
		}
		if (Progression.previousScene == "Town") {
			player.cc.transform.position = new Vector3(56f, 6f, -1f);
		}
		if (Progression.previousScene == "BunnyIsle") {
			player.cc.transform.position = new Vector3(-38f, 44f, -1f);
		}
		fadeScript.fade = true;
		fadeScript.fadingOut = true;
		fadeScript.bothFades = false;
		
		if(Progression.treesCut){
			Destroy (GameObject.Find ("Treechete"));
		}
		Progression.reKey = true;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(!Progression.treesCut && Progression.hasHatchet && treeCut.clicked == true){
				Destroy(GameObject.Find("Treechete"));
				Progression.treesCut = true;
		}
		else if(!Progression.treesCut && !Progression.hasHatchet && treeCut.clicked == true){
			GUI.Box (new Rect (0, Screen.height - Screen.height/4f - messageHeight/2f,
			                   Screen.width, messageHeight),
			         "Looks like I need a hatchet to continue, maybe the old lady might have one.");
		}
		switch(Progression.progress){
			case 8:
				QuestBar.barHeight = Screen.height/6f;
				QuestBar.task = "From your home on the hill, you gaze out at the dawn-lit ocean that was once your beloved town.\n The moon catches your eye. It's been split asunder. In an Earth-shattering splash, a hurling chunk of flaming moonstone\n strikes you from the sky. You awake from the frigthening dream glad it was only a nightmare.";
				player.allowedToMove = false;
				if(!fadeScript.fade){
					if (GUI.Button (new Rect (Screen.width/2f - (9 *(Screen.width / 100f)/2f), Screen.height/2.8f - (8 *(Screen.height / 100f)/2f),
				                          9 *(Screen.width / 100f), 8 *(Screen.height / 100f)), "Next")){
				        clicked = true;			
					}
				}
				if(clicked)
				{
					if(temp){
						fadeScript.fade = true;
						fadeScript.fadingIn = true;
						fadeScript.bothFades = true;
						temp = false;
					}
					if(fadeScript.fadingIn == false){
						clicked = false;
						Progression.progress++;
						player.allowedToMove = true;
						Application.LoadLevel ("Home2");
					}
				}
				break;
			case 11:
				QuestBar.task = "Find the keys to unlock the gate. " + Progression.keysFound + "/3 keys found.";
				if(Progression.reKey){
					switch(Progression.keysFound){
						case 0://chickens drop keys
							foreach(GameObject keyEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
							{
								if(keyEnemy.name == "Enemy_Chicken_Key")
								{
									keyEnemy.GetComponent<MeleeEnemyAI>().drops[6] = 8;
								}
							}
							Progression.reKey = false;
							break;
						case 1://big goblin drops keys and chickens dont anymore
							foreach(GameObject keyEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
							{
								if(keyEnemy.name == "Enemy_Goblin_Key")
								{
									keyEnemy.GetComponent<MeleeEnemyAI>().drops[6] = 25;
								}
								if(keyEnemy.name == "Enemy_Chicken_Key")
								{
									keyEnemy.GetComponent<MeleeEnemyAI>().drops[6] = 0;
								}
							}
							Progression.reKey = false;
							break;
						case 3:
							Progression.keysFound = 0;
							Progression.progress++;
							break;
					}
				}
				break;
			case 12:
				QuestBar.task = "Return the keys to your neighbor and head to the town.";
				break;
		}
	}
}
