using UnityEngine;
using System.Collections;

public class PlayerMana : MonoBehaviour {

	//private GameObject inventory;                        // Reference to the player.
	//private var playerInventory : PlayerInventory;      // Reference to the player's inventory.
	public GameObject inventory;
	public float manaBarLength;
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
		adjustCurrentMana();
		
	}
	
	void OnGUI(){
		style = new GUIStyle( GUI.skin.box );
		style.fontSize = 20;
		GUI.color = Color.white;
		GUI.Box(new Rect(10,130,200,30),"Mana:" + playerInventory.currentMP + "/" + playerInventory.fullMP, style);
		InitStyles();
		GUI.Box(new Rect(10, 160, manaBarLength, 30), "", currentStyle);
	}
	private void InitStyles()
		
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( 2, 2, Color.blue );
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
	//adjusts current mana and changes length of the mana bar.
	public void adjustCurrentMana(){
		manaBarLength = (Screen.width/4) * (playerInventory.currentMP / (float)playerInventory.fullMP); 
		
	}
}
