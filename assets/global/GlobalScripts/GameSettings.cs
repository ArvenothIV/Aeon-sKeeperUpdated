using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

	private float playerX;
	private float playerY;
	private GameObject player;
	GameObject js;
	public PlayerInventory jScript;
	private WorldButtonInteraction wb;

	//So the object doesn't get destroyed on loading levels.
	void Awake(){
		DontDestroyOnLoad(this);

	}

	// Use this for initialization
	void Start () {
//		if(PlayerPrefs.HasKey("HP"))
//			jScript.fullHP = PlayerPrefs.GetInt("HP");

	}

	// Update is called once per frame
	void Update () {

	}

	public void SaveCharData(){
		PlayerPrefs.DeleteAll();            //makes sure nothing bad is left over
		player = GameObject.FindGameObjectWithTag("Player");
		
		PlayerPrefs.SetString("currentLvl", Application.loadedLevelName);
		//Debug.Log (PlayerPrefs.GetString("currentLvl"));
		PlayerPrefs.SetInt ("Player Class", Progression.playerClass);
		Debug.Log(jScript.hasSword);
		PlayerPrefs.SetInt("Has Sword", (jScript.hasSword ? 1 : 0));
		Debug.Log(jScript.hasSword);
		PlayerPrefs.SetInt("Has Armor", (jScript.hasArmor ? 1 : 0));
		PlayerPrefs.SetInt("Has Helm", (jScript.hasHelm ? 1 : 0));
		PlayerPrefs.SetInt("Has Bow", (jScript.hasBow ? 1 : 0));
		PlayerPrefs.SetInt("Has Staff", (jScript.hasStaff ? 1 : 0));
		PlayerPrefs.SetInt("Strength", jScript.currentATK);
		Debug.Log(jScript.currentATK);
		PlayerPrefs.SetInt("Agility", jScript.currentAGI);
		PlayerPrefs.SetInt("Intelligence", jScript.currentINT);
		PlayerPrefs.SetInt("Luck", jScript.currentLUC);
		PlayerPrefs.SetInt("Current EXP", jScript.currentEXP);
		PlayerPrefs.SetInt("Next EXP", jScript.currentNEXT);
		PlayerPrefs.SetInt("Player level", jScript.currentLV);
		PlayerPrefs.SetInt ("HP", jScript.fullHP);
		Debug.Log (jScript.fullHP);
		PlayerPrefs.SetInt ("MP", jScript.fullMP);
		PlayerPrefs.SetInt ("Generation", jScript.generation);

		SavePlayerPosition(player);
		SaveProgression ();
		SaveItemInfo();

		PlayerPrefs.Save ();
	}

	public void SaveProgression(){
		//save quest info
		PlayerPrefs.SetInt ("Story Progress", Progression.progress);
		PlayerPrefs.SetInt ("Has Hatchet", (Progression.hasHatchet ? 1 : 0));
		PlayerPrefs.SetInt ("Number of keys found", Progression.keysFound);
		PlayerPrefs.SetInt("Kill Count", Progression.killCount);
		PlayerPrefs.SetInt("Trees Cut", (Progression.treesCut ? 1 : 0));
		PlayerPrefs.SetInt("reKey", (Progression.reKey ? 1 : 0));
		PlayerPrefs.SetInt("Has Pot", (Progression.hasPot ? 1 : 0));
		PlayerPrefs.SetInt("Rented room", (Progression.hasRentedRoom ? 1 : 0));
		PlayerPrefs.SetInt("Charcoal", (Progression.hasCharcoal ? 1 : 0));
		PlayerPrefs.SetInt("Drink", (Progression.hasDrink ? 1 : 0));
		PlayerPrefs.SetInt("Drugged drink", (Progression.hasDruggedDrink ? 1 : 0));
		PlayerPrefs.SetInt("Vinegar", (Progression.hasVinegar ? 1 : 0));
		PlayerPrefs.SetInt("Drugged Jailer", (Progression.hasDruggedJailer ? 1 : 0));
		PlayerPrefs.SetInt("reHerb", (Progression.reHerb ? 1 : 0));
		PlayerPrefs.SetInt("Herbs collected", (Progression.herbsCollected));
		PlayerPrefs.SetInt("Chest unlocked", (Progression.chestUnlocked ? 1 : 0));
		PlayerPrefs.SetInt("Dungeon complete", (Progression.dungeonCompleted ? 1 : 0));
		PlayerPrefs.SetInt("Sands", (Progression.hasSands ? 1 : 0));
//		PlayerPrefs.SetInt("Clicked", (WorldButtonInteraction.Clicked ? 1 : 0));
		PlayerPrefsX.SetIntArray("Levers", Progression.levers);
	}

	private void SaveItemInfo(){
		js = GameObject.FindGameObjectWithTag ("PlayerInventory");
		jScript = js.GetComponent<PlayerInventory> ();
		if (jScript.hasSword) {
			PlayerPrefs.SetInt("Has Sword", 1);
			PlayerPrefs.SetInt("Has Staff", 0);
			PlayerPrefs.SetInt("Has Bow", 0);
			PlayerPrefs.SetString ("Sword Name", jScript.itemlistSwordName);
			PlayerPrefs.SetInt("Sword Str", jScript.itemlistSwordStrength);
			PlayerPrefs.SetInt("Sword Agl", jScript.itemlistSwordAgil);
			PlayerPrefs.SetInt("Sword Int", jScript.itemlistSwordIntel);
			PlayerPrefs.SetInt("Sword Lck", jScript.itemlistSwordLuck);
		}
		else if (jScript.hasStaff) {
			PlayerPrefs.SetInt("Has Sword", 0);
			PlayerPrefs.SetInt("Has Staff", 1);
			PlayerPrefs.SetInt("Has Bow", 0);
			PlayerPrefs.SetString ("Staff Name", jScript.itemlistStaffName);
			PlayerPrefs.SetInt("Staff Str", jScript.itemlistStaffStrength);
			PlayerPrefs.SetInt("Staff Agl", jScript.itemlistStaffAgil);
			PlayerPrefs.SetInt("Staff Int", jScript.itemlistStaffIntel);
			PlayerPrefs.SetInt("Staff Lck", jScript.itemlistStaffLuck);
		}
		else if (jScript.hasBow) {
			PlayerPrefs.SetInt("Has Sword", 0);
			PlayerPrefs.SetInt("Has Staff", 0);
			PlayerPrefs.SetInt("Has Bow", 1);
			PlayerPrefs.SetString ("Bow Name", jScript.itemlistBowName);
			PlayerPrefs.SetInt("Bow Str", jScript.itemlistBowStrength);
			PlayerPrefs.SetInt("Bow Agl", jScript.itemlistBowAgil);
			PlayerPrefs.SetInt("Bow Int", jScript.itemlistBowIntel);
			PlayerPrefs.SetInt("Bow Lck", jScript.itemlistBowLuck);
		}

		if (jScript.hasHelm) {
			PlayerPrefs.SetString ("Helm Name", jScript.itemlistHelmName);
			PlayerPrefs.SetInt("Helm Str", jScript.itemlistHelmStrength);
			PlayerPrefs.SetInt("Helm Agl", jScript.itemlistHelmAgil);
			PlayerPrefs.SetInt("Helm Int", jScript.itemlistHelmIntel);
			PlayerPrefs.SetInt("Helm Lck", jScript.itemlistHelmLuck);
		}
		else if (jScript.hasArmor) {
			PlayerPrefs.SetString ("Armor Name", jScript.itemlistArmorName);
			PlayerPrefs.SetInt("Armor Str", jScript.itemlistArmorStrength);
			PlayerPrefs.SetInt("Armor Agl", jScript.itemlistArmorAgil);
			PlayerPrefs.SetInt("Armor Int", jScript.itemlistArmorIntel);
			PlayerPrefs.SetInt("Armor Lck", jScript.itemlistArmorLuck);
		}
	}

	public void LoadProgression(){

		if(PlayerPrefs.HasKey("Story Progress"))
			Progression.progress = PlayerPrefs.GetInt("Story Progress");
		
		if(PlayerPrefs.HasKey("Has Hatchet")){
			if(PlayerPrefs.GetInt("Has Hatchet") == 0)
				Progression.hasHatchet = false;
			else
				Progression.hasHatchet = true;
			
			if(PlayerPrefs.GetInt("Trees Cut") == 0)
				Progression.treesCut = false;
			else{
				Progression.treesCut = true;
				Destroy(GameObject.Find("Treechete"));
			}
		}

		if(PlayerPrefs.HasKey("reKey")){
			if(PlayerPrefs.GetInt("reKey") == 0)
				Progression.reKey = false;
			else
				Progression.reKey = true;
		}

		if(PlayerPrefs.HasKey("Has Pot") && PlayerPrefs.GetInt("Has Pot") == 0)
			Progression.hasPot = false;
		else
			Progression.hasPot = true;
		
		if(PlayerPrefs.HasKey("Rented room") && PlayerPrefs.GetInt("Rented room") == 0)
			Progression.hasRentedRoom = false;
		else
			Progression.hasRentedRoom = true;
		
		if(PlayerPrefs.HasKey("Charcoal") && PlayerPrefs.GetInt("Charcoal") == 0)
			Progression.hasCharcoal = false;
		else
			Progression.hasCharcoal = true;
		
		if(PlayerPrefs.HasKey("Drink") && PlayerPrefs.GetInt("Drink") == 0)
			Progression.hasDrink = false;
		else
			Progression.hasDrink = true;
		
		if(PlayerPrefs.HasKey("Drugged drink") && PlayerPrefs.GetInt("Drugged drink") == 0)
			Progression.hasDruggedDrink = false;
		else
			Progression.hasDruggedDrink = true;
		
		if(PlayerPrefs.HasKey("Vinegar") && PlayerPrefs.GetInt("Vinegar") == 0)
			Progression.hasVinegar = false;
		else
			Progression.hasVinegar = true;
		
		if(PlayerPrefs.HasKey("Drugged Jailer") && PlayerPrefs.GetInt("Drugged Jailer") == 0)
			Progression.hasDruggedJailer = false;
		else
			Progression.hasDruggedJailer = true;
		
		if(PlayerPrefs.HasKey("reHerb") && PlayerPrefs.GetInt("reHerb") == 0)
			Progression.reHerb = false;
		else
			Progression.reHerb = true;
		
		if(PlayerPrefs.HasKey("Herbs collected"))
			Progression.herbsCollected = PlayerPrefs.GetInt("Herbs collected");
		
		if(PlayerPrefs.HasKey("Chest unlocked") && PlayerPrefs.GetInt("Chest unlocked") == 0)
			Progression.chestUnlocked = false;
		else
			Progression.chestUnlocked = true;
		
		if(PlayerPrefs.HasKey("Dungeon complete") && PlayerPrefs.GetInt("Dungeon complete") == 0)
			Progression.dungeonCompleted = false;
		else
			Progression.dungeonCompleted = true;
		
		if(PlayerPrefs.HasKey("Sands") && PlayerPrefs.GetInt("Sands") == 0)
			Progression.hasSands = false;
		else
			Progression.hasSands = true;
		
		if(PlayerPrefs.HasKey("Levers"))
			Progression.levers = PlayerPrefsX.GetIntArray("Levers");
	}

	public void LoadCharData(){		

		if(PlayerPrefs.HasKey("Player Class"))
			Progression.playerClass = PlayerPrefs.GetInt("Player Class");

		jScript.currentATK = PlayerPrefs.GetInt("Strength");
		jScript.currentAGI =PlayerPrefs.GetInt("Agility");
		jScript.currentINT = PlayerPrefs.GetInt("intelligence");
		jScript.currentLUC = PlayerPrefs.GetInt("Luck");
		jScript.currentEXP = PlayerPrefs.GetInt("Curent EXP");
		jScript.currentNEXT = PlayerPrefs.GetInt("Next EXP");
		jScript.currentLV = PlayerPrefs.GetInt("Player level");
		jScript.generation = PlayerPrefs.GetInt ("Generation");

		jScript.fullHP = PlayerPrefs.GetInt ("HP");
		Debug.Log (jScript.fullHP);
		jScript.currentHP = jScript.fullHP;
		jScript.fullMP = PlayerPrefs.GetInt ("MP");
		jScript.currentMP = jScript.fullMP;

		LoadCharacterPosition();
		LoadProgression();


		if(PlayerPrefs.HasKey("Has Sword") && PlayerPrefs.GetInt("Has Sword") == 1)
			jScript.hasSword = true;
		
		if(PlayerPrefs.HasKey("Has Armor") && PlayerPrefs.GetInt("Has Armor") == 1)
			jScript.hasArmor = true;
		
		if(PlayerPrefs.HasKey("Has Helm") && PlayerPrefs.GetInt("Has Helm") == 1)
			jScript.hasHelm = true;
		
		if(PlayerPrefs.HasKey("Has Bow") && PlayerPrefs.GetInt("Has Bow") == 1)
			jScript.hasBow = true;
		
		if(PlayerPrefs.HasKey("Has Staff") && PlayerPrefs.GetInt("Has Staff") == 1)
			jScript.hasStaff = true;

		LoadItemInfo ();

		if(PlayerPrefs.HasKey("currentLvl")){
			Debug.Log (PlayerPrefs.GetString("currentLvl"));
			Progression.firstLevelToLoad = PlayerPrefs.GetString("currentLvl");
			Debug.Log (Progression.firstLevelToLoad);
			Application.LoadLevel("makePlayer");
		}
	}

	public void SavePlayerPosition(GameObject player){
		PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
		PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
	}

	public void LoadCharacterPosition(){
		playerX = PlayerPrefs.GetFloat("PlayerPosX");
		playerY = PlayerPrefs.GetFloat("PlayerPosY");
		Vector3 _pos = new Vector3(playerX, playerY, -1.0f);
		Progression.charPos = _pos;

	}

	private void LoadItemInfo(){
		if (jScript.hasSword) {
			Debug.Log (PlayerPrefs.GetString("Sword Name"));
			jScript.itemlistSwordName = PlayerPrefs.GetString("Sword Name");
			jScript.itemlistSwordStrength = PlayerPrefs.GetInt("Sword Str");
			jScript.itemlistSwordAgil = PlayerPrefs.GetInt("Sword Agl");
			jScript.itemlistSwordLuck = PlayerPrefs.GetInt("Sword Lck");
		}
		else if (jScript.hasStaff) {
			Debug.Log (PlayerPrefs.GetString("Staff Name"));
			jScript.itemlistStaffName = PlayerPrefs.GetString("Staff Name");
			jScript.itemlistStaffStrength = PlayerPrefs.GetInt("Staff Str");
			jScript.itemlistStaffAgil = PlayerPrefs.GetInt("Staff Agl");
			jScript.itemlistStaffLuck = PlayerPrefs.GetInt("Staff Lck");
		}
		else if (jScript.hasBow) {
			Debug.Log (PlayerPrefs.GetString("Bow Name"));
			jScript.itemlistBowName = PlayerPrefs.GetString("Bow Name");
			jScript.itemlistBowStrength = PlayerPrefs.GetInt("Bow Str");
			jScript.itemlistBowAgil = PlayerPrefs.GetInt("Bow Agl");
			jScript.itemlistBowLuck = PlayerPrefs.GetInt("Bow Lck");
		}

		if (jScript.hasArmor) {
			Debug.Log (PlayerPrefs.GetString("Armor Name"));
			jScript.itemlistArmorName = PlayerPrefs.GetString("Armor Name");
			jScript.itemlistArmorStrength = PlayerPrefs.GetInt("Armor Str");
			jScript.itemlistArmorAgil = PlayerPrefs.GetInt("Armor Agl");
			jScript.itemlistArmorLuck = PlayerPrefs.GetInt("Armor Lck");
		}

		if (jScript.hasHelm) {
			Debug.Log (PlayerPrefs.GetString("Helm Name"));
			jScript.itemlistHelmName = PlayerPrefs.GetString("Helm Name");
			jScript.itemlistHelmStrength = PlayerPrefs.GetInt("Helm Str");
			jScript.itemlistHelmAgil = PlayerPrefs.GetInt("Helm Agl");
			jScript.itemlistHelmLuck = PlayerPrefs.GetInt("Helm Lck");
		}
	}

	public void ResetGameSettings(){
		Progression.progress = 0;
		Progression.previousScene = "makePlayer";
		Progression.playerClass = 1;
		Progression.killCount = 0;
		Progression.goldOfLastEnemy = 0;

		Progression.firstLevelToLoad = "Tutorial1";
		Progression.charPos = new Vector3(0f, 0f, -100f);

		Progression.hasHatchet = false;
		Progression.treesCut = false;
		Progression.keysFound = 0;
		Progression.reKey = false;
	
		Progression.hasPot = false;
		Progression.hasRentedRoom = false;
		Progression.hasCharcoal = false;
		Progression.hasDrink = false;
		Progression.hasDruggedDrink = false;
		Progression.hasVinegar = false;
		Progression.hasDruggedJailer = false;
	
		Progression.herbsCollected = 0;
		Progression.reHerb = false;
		Progression.chestUnlocked = false;
		Progression.dungeonCompleted = false;
		Progression.hasSands = false;

		for (int i = 0; i < Progression.levers.Length; i++)
			Progression.levers[i] = 0;
	}
}
