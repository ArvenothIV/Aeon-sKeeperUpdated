using UnityEngine;
using System.Collections;

public class Levers : MonoBehaviour {

	private WorldButtonInteraction WBI;
	public int leverNumber;
	private string directionString;
	// Use this for initialization
	void Start () {
		WBI = this.GetComponent<WorldButtonInteraction>();
		if(leverNumber == 0){directionString = "South-West.";}
		else if(leverNumber == 1){directionString = "East.";}
		else if(leverNumber == 2){directionString = "South-West.";}
		else if(leverNumber == 3){directionString = "South-East.";}
		else { directionString = "West.";}
	}
	
	// Update is called once per frame
	void OnGUI() {
		if(WBI.clicked){//0 , 1 , 2 ,3 , 4 , 5 , 6 , 7 , 8 , 9
			GUI.Box (new Rect (0, Screen.height/3.5f - WBI.messageHeight/2f,
			                   Screen.width, WBI.messageHeight),
			         "This dial is set at " + Progression.levers[leverNumber] + ". The device is pointing to the "+ directionString);
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight*5.5f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "0")){
			    Progression.levers[leverNumber] = 0;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight*4.4f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "1")){
				Progression.levers[leverNumber] = 1;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight*3.3f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "2")){
				Progression.levers[leverNumber] = 2;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight*2.2f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "3")){
				Progression.levers[leverNumber] = 3;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight*1.1f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "4")){
				Progression.levers[leverNumber] = 4;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight + WBI.messageHeight*1.1f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "5")){
				Progression.levers[leverNumber] = 5;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight + WBI.messageHeight*2.2f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "6")){
				Progression.levers[leverNumber] = 6;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight + WBI.messageHeight*3.3f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "7")){
				Progression.levers[leverNumber] = 7;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight + WBI.messageHeight*4.4f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "8")){
				Progression.levers[leverNumber] = 8;
				WBI.clicked = false;
			}
			if(GUI.Button (new Rect (Screen.width/2f - WBI.messageHeight + WBI.messageHeight*5.5f,
			    Screen.height/2.2f - WBI.messageHeight/2f, WBI.messageHeight, WBI.messageHeight), "9")){
				Progression.levers[leverNumber] = 9;
				WBI.clicked = false;
			}
		}
	}
}
