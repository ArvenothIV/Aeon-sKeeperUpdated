using UnityEngine;
using System.Collections;

public class DarkAttack : MonoBehaviour {

	public GameObject inventory;
	private PlayerInventory playerInventoryPrivate;
	private Vector3 attackPath;
	private float deathTimer;
	// Use this for initialization
	void Start () 
	{
		inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
		playerInventoryPrivate = inventory.GetComponent<PlayerInventory>();
		attackPath = GameObject.FindGameObjectWithTag("Player").transform.position - this.gameObject.transform.position;
		attackPath.Normalize ();
		deathTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(attackPath*0.08f);
		if(deathTimer > 10)
		{
			Destroy(this.gameObject);
		}
		deathTimer += Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			playerInventoryPrivate.currentHP -= 25;
			Destroy(this.gameObject);
		}
	}
}
