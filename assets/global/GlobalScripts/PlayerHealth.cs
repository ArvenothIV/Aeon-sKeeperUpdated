using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	//private GameObject inventory;                        // Reference to the player.
	//private var playerInventory : PlayerInventory;      // Reference to the player's inventory.
	public GameObject inventory;
	public float healthBarLength;
	private PlayerInventory playerInventory;
	private GUIStyle currentStyle = null;
	private GUIStyle style = null;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		healthBarLength = Screen.width/2;
	}
	
	// Update is called once per frame
	void Update () {
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
			playerInventory = inventory.GetComponent<PlayerInventory>();
		adjustCurrentHealth();
		
	}

	void OnGUI(){
		style = new GUIStyle( GUI.skin.box );
		style.fontSize = 20;
		GUI.color = Color.white;
		GUI.Box(new Rect(10,70,200,30),"Health:" + playerInventory.currentHP + "/" + playerInventory.fullHP,style);
		InitStyles();
		GUI.Box(new Rect(10,100, healthBarLength, 30),"", currentStyle);
	}
	private void InitStyles()
		
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( 2, 2, Color.red );
			currentStyle.fontSize = 20;
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col )
		
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
		
	}

	//adjusts the current health and changes length of health bar
	public void adjustCurrentHealth(){
		healthBarLength = (Screen.width/4) * (playerInventory.currentHP / (float)playerInventory.fullHP); 
	
	}
}
