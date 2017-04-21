using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {


	public GameObject inventory;
	private PlayerInventory playerInventoryPrivate;
	public int health;
	public int damageMultiplyer;
	private float chargeTimer;
	private Vector2 bossMoveVector;
	private bool charge;
	private bool patrol;
	private bool dead;
	public Vector3 currentLocal;
	public bool startFight;
	private float fireTimer;
	
	// Use this for initialization
	void Start () 
	{
		currentLocal = this.transform.position;
		chargeTimer = 0;
		charge = false;
		patrol = true;
		dead = false;
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventoryPrivate = inventory.GetComponent<PlayerInventory>();
		startFight = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startFight) 
		{
			if (health <= 0) 
			{
					dead = true;
					Vector3 tempLoc = GameObject.Find ("Boss").transform.position;
					Destroy (this.gameObject);
					GameObject.Find("Down_3").transform.position = tempLoc;
					QuestBar.barHeight = Screen.height / 9f;
					QuestBar.title = "Aeon's Keeper:";
					QuestBar.task = "Talk To Aeon.";
					//Progression.progress = 20;
			}
			int temp;
			if (chargeTimer > Random.Range (10, 20) && charge == false) 
			{
					charge = true;
					chargeTimer = 0;
			}
			if (fireTimer > 20) 
			{
					Instantiate (Resources.Load ("DarkAttack"), this.gameObject.transform.position, this.gameObject.transform.rotation);
					fireTimer = 0;
			}

			if (charge) 
			{
				patrol = false;
				bossMoveVector = chargeForward();
				charge = false;
			}
			if (patrol)
			{
				bossMoveVector = bossPatrol();
			}

			moveBoss(bossMoveVector);
			chargeTimer += Time.deltaTime;
			fireTimer += Time.deltaTime;
		}
	}
	
	Vector2 bossPatrol()
	{
		Vector2 toTarget = GameObject.FindGameObjectWithTag("Player").transform.position - this.gameObject.transform.position;
		toTarget.Normalize();
		return toTarget * 0.05f;
	}

	Vector2 chargeForward()
	{
		Vector2 toTarget = GameObject.FindGameObjectWithTag("Player").transform.position - this.gameObject.transform.position;
		toTarget.Normalize ();
		return toTarget * 0.32f;
	}

	void moveBoss(Vector2 v)
	{
		this.gameObject.transform.Translate (v);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerInventoryPrivate.currentHP -= 30;
		} 
		else 
		{
			patrol = true;
		}
	}
}
