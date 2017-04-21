using UnityEngine;
using System.Collections;

public class newGameButton : MonoBehaviour {
	
	private GameObject _object;
	private GameSettings gs;

	void OnMouseDown () {
		_object = GameObject.FindGameObjectWithTag ("GameSettings");
		gs = _object.GetComponent<GameSettings> ();

		if(Input.GetMouseButtonDown (0)){
			PlayerPrefs.DeleteAll();
			gs.ResetGameSettings();
			Application.LoadLevel("SelectionScreen");
		}
		
	}
}

