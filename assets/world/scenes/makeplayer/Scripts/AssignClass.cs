using UnityEngine;
using System.Collections;

public class AssignClass : MonoBehaviour {
	
	// Use this for initialization
	private GameObject player;
	private GameObject inventory;
	
	
	public Sprite c1Sprite;
	public RuntimeAnimatorController c1Controller;
	public Sprite c2Sprite;
	public RuntimeAnimatorController c2Controller;
	public Sprite c3Sprite;
	public RuntimeAnimatorController c3Controller;
	public Sprite c4Sprite;
	public RuntimeAnimatorController c4Controller;
	public Texture inv1Sprite;
	public Texture inv2Sprite;
	public Texture inv3Sprite;
	public Texture inv4Sprite;
	public Texture skillSprite1;
	public Texture skillSprite2;
	public Texture skillSprite3;
	public Texture skillSprite4;
	
	void Start () {
		player = GameObject.Find("Player");
		inventory = GameObject.Find ("Inventory");
		switch(Progression.playerClass){
		case 1:
			player.GetComponent<SpriteRenderer>().sprite = c1Sprite;
			player.GetComponent<Animator>().runtimeAnimatorController = c1Controller;
			inventory.GetComponent<PlayerInventory>().t_hero = inv1Sprite;
			inventory.GetComponent<PlayerInventory>().t_skillBox = skillSprite1;
			break;
		case 2:
			player.GetComponent<SpriteRenderer>().sprite = c2Sprite;
			player.GetComponent<Animator>().runtimeAnimatorController = c2Controller;
			inventory.GetComponent<PlayerInventory>().t_hero = inv2Sprite;
			inventory.GetComponent<PlayerInventory>().t_skillBox = skillSprite2;
			break;
		case 3:
			player.GetComponent<SpriteRenderer>().sprite = c3Sprite;
			player.GetComponent<Animator>().runtimeAnimatorController = c3Controller;
			inventory.GetComponent<PlayerInventory>().t_hero = inv3Sprite;
			inventory.GetComponent<PlayerInventory>().t_skillBox = skillSprite3;
			break;
		case 4:
			player.GetComponent<SpriteRenderer>().sprite = c4Sprite;
			player.GetComponent<Animator>().runtimeAnimatorController = c4Controller;
			inventory.GetComponent<PlayerInventory>().t_hero = inv4Sprite;
			inventory.GetComponent<PlayerInventory>().t_skillBox = skillSprite4;
			break;
		}
		
		Progression.previousScene = Application.loadedLevelName;
		Application.LoadLevel(Progression.firstLevelToLoad);
	}
}
