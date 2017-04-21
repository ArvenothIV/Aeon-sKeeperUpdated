using UnityEngine;
using System.Collections;

public class QuestBar : MonoBehaviour {

	public static string title = "Dream:";
	public static string task = "This in the quest bar. It will guide you throughout your journey. Press 'Q' twice to untoggle and toggle it.";
	public static bool toggled = true;
	public static float barHeight = Screen.height / 11f;
	
	private string demoStr = "";
	private bool hitD = false;
	private bool hitE = false;
	private bool hitM = false;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}

	void OnGUI()
	{
		GUI.skin.box.fontSize = (int)(Screen.height/30);
		if (toggled) {
			GUI.Box (new Rect (0f, 0f, Screen.width,
				barHeight), title + demoStr + "\n" + task);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			toggled = !toggled;
		}
		
		//switch to demo
		if(Input.GetKeyDown(KeyCode.D)){
			hitD = true;
			hitM = false;
			hitE = false;
		}
		if(Input.GetKeyDown(KeyCode.E)){
			if(hitD){
				hitE = true;
				hitD = false;
				hitM = false;
			}
			else{
				hitD = false;
				hitE = false;
				hitM = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.M) && hitE){
			if(hitE){
				hitM = true;
				hitE = false;
				hitD = false;
			}
			else {
				hitD = false;
				hitE = false;
				hitM = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.O) && hitM){
			Progression.isDemo = !Progression.isDemo;
			if(Progression.isDemo){ demoStr = " (DEMO)"; Progression.goldOfLastEnemy = 20000;}
			else{ demoStr = "";}
			hitM = false;
		}
	}
}
