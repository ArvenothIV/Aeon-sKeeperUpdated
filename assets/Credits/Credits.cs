using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject camera;
	public float speed = 1f;
	public string level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		camera.transform.Translate(Vector3.down * Time.deltaTime * speed);
	}

	IEnumerator waitFor(){
	
		yield return new WaitForSeconds(20);
		Application.LoadLevel ("Tutorial1");
	}
}
