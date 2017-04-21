using UnityEngine;
using System.Collections;

public class Progression : MonoBehaviour {

	// Use this for initialization
	public static int progress = 0;
	public static string previousScene = "makePlayer";
	public static int playerClass = 1;
	public static int killCount = 0;
	public static int goldOfLastEnemy = 0;

	// Info for loading correct character position
	public static string firstLevelToLoad = "Tutorial1";
	public static Vector3 charPos = new Vector3(0f, 0f, -100f);
	
	//key quest
	public static bool hasHatchet = false;
	public static bool treesCut = false;
	public static int keysFound = 0;
	public static bool reKey = false;/*True if previous key found and at quest start.
									False once right enemies are allowed to drop keys. 
									Reduces lag by not constantly finding all enemies.*/
									
	//prison quest
	public static bool hasPot = false;
	public static bool hasRentedRoom = false;
	public static bool hasCharcoal = false;
	public static bool hasDrink = false;
	public static bool hasDruggedDrink = false;
	public static bool hasVinegar = false;
	public static bool hasDruggedJailer = false;
	
	//ritual quest
	public static int[] levers = {0,0,0,0,0};	
	public static int herbsCollected = 0;
	public static bool reHerb = false;
	public static bool chestUnlocked = false;
	public static bool dungeonCompleted = false;
	public static bool hasSands = false;
	
	//Demo (doesn't need to be saved)
	public static bool isDemo = false;

	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
