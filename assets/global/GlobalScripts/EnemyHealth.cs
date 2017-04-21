using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	//private GameObject inventory;                        // Reference to the player.
	//private var playerInventory : PlayerInventory;      // Reference to the player's inventory.
	public GameObject enemy;
	public float healthBarLength;
	private MeleeEnemyAI meleeEnemy;
	private GUIStyle currentStyle = null;
	//private Transform target;
	//private Vector3 wantedPos;
	private Vector2 targetPos;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		healthBarLength = Screen.width/2;
	}
	
	// Update is called once per frame
	void Update () {
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		meleeEnemy = enemy.GetComponent<MeleeEnemyAI>();
		adjustCurrentHealth();
		//screenPos = Camera.main.WorldToViewportPoint(this.transform.position);
		//wantedPos = Camera.main.WorldToViewportPoint(target);
		targetPos = Camera.main.WorldToScreenPoint (this.transform.position);

		//transform.position = wantedPos;
		
	}
	
	void OnGUI(){
		InitStyles();
		GUI.Box(new Rect(targetPos.x,targetPos.y + 20, healthBarLength, 30), 
		        "Health:" + meleeEnemy.health + "/" + meleeEnemy.maxhealth, currentStyle);
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
		healthBarLength = (Screen.width/4) * (meleeEnemy.health / (float)meleeEnemy.maxhealth); 
		
	}
}
