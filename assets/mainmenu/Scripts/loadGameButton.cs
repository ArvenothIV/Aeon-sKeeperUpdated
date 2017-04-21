using UnityEngine;
using System.Collections;

public class loadGameButton : MonoBehaviour {

	private GameSettings gsScript;
	private GameObject gs;
	public GameObject CharacterStats;

	void OnMouseDown () {
		if(Input.GetMouseButtonDown (0)){
			gs = GameObject.FindGameObjectWithTag("GameSettings");
			gsScript = gs.GetComponent<GameSettings>();
			//if( gsScript.saveExist){
			if(PlayerPrefs.HasKey("currentLvl"))			
				gsScript.LoadCharData();
			//}
		}
		
	}
}

