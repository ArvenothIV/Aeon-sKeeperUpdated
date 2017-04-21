using UnityEngine;
using System.Collections;


public class Attack : MonoBehaviour {
	
	public GameObject enemy;
	private MeleeEnemyAI aEnemy;
	public GameObject inventory;
	private PlayerInventory aInventory;
	public GameObject boss;
	private BossAI aBoss;
	
	private float redHitTime = 0.2f;
	private float redHitTimer;
	private bool red = false;

	// Use this for initialization
	void Start(){


		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		aInventory = inventory.GetComponent<PlayerInventory>();
		boss = GameObject.FindGameObjectWithTag("Boss");
		aBoss = boss.GetComponent<BossAI>();

	}
	
	// Update is called once per frame
	void Update () {
		if(red && redHitTimer > 0)
		{
			redHitTimer -= Time.deltaTime;
		}
		else if(red && redHitTimer <= 0 && aEnemy != null)
		{
			aEnemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			aBoss.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			red = false;
		}	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy" && this.tag != "Enemy")
		{
			aEnemy = col.GetComponent<MeleeEnemyAI>();
			//do damage to enemy
			aEnemy.health = aEnemy.health - aInventory.currentATK;
			//color the enemy red on hit
			aEnemy.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f);
			redHitTimer = redHitTime;
			red = true;
		}
		else if (col.tag == "Boss"){
			aBoss.health = aBoss.health - aInventory.currentATK;
			aBoss.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f);
			redHitTimer = redHitTime;
			red = true;
			Debug.Log ("hit!");
		}
		else{
		}
	}
}
