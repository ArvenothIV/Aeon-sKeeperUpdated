using UnityEngine;
using System.Collections;

public class Generation : MonoBehaviour {
	public GameObject inventory;
	private PlayerInventory playerInventory;
	// Use this for initialization
	private GUIStyle currentStyle = null;
	private GUIStyle style = null;
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventory = inventory.GetComponent<PlayerInventory>();
		
	}
	
	void OnGUI(){
		style = new GUIStyle( GUI.skin.box );
		style.fontSize = 20;
		GUI.color = Color.white;
		GUI.Box(new Rect(10,190,200,30),"Generation: " + playerInventory.generation, style);
	}
}
