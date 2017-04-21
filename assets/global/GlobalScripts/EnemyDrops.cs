using UnityEngine;
using System.Collections;

public class EnemyDrops : MonoBehaviour {

	public GameObject[] drops;//sword, armor, helm, bow, staff, potion, key, manapotion 
							  //  0  ,   1  ,  2  ,  3 ,   4  ,   5   ,  6,      7
	private int tally = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void drop(int[] dropList, int maxDropCount, Vector3 pos){
		tally = 0;
		System.Random rngesus = new System.Random();
		int roll = rngesus.Next(1, maxDropCount);
		for(int i = 0; i < dropList.Length; i++){
			tally += dropList[i];
			if(dropList[i] != 0 && roll <= tally){
				GameObject swordClone = (GameObject)Instantiate(drops[i], pos, Quaternion.identity);
				Destroy (swordClone,10f);
				break;
			}
		}
	}
}
