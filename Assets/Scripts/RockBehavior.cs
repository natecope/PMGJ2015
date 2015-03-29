using UnityEngine;
using System.Collections;

public class RockBehavior : MonoBehaviour {

	//so we can get object speed
	public LevelManager levelManager;

	//rock break particles
	public GameObject rockDestroyParticles;

	//how wide?
	public int tileWidth = 2;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newPos = new Vector2();
		newPos.y = transform.position.y + levelManager.bottomObjectsMoveSpeed * Time.deltaTime;
		newPos.x = transform.position.x;
		transform.position = newPos;

		if(transform.position.y > levelManager.mapHeight){

			Destroy(gameObject);

		}
	}



	void OnTriggerEnter2D(Collider2D other){
		
		Debug.Log ("collision detecteed from " + other.gameObject.tag);
		if(other.gameObject.tag == "Drill"){

			Instantiate(rockDestroyParticles, other.gameObject.transform.position, transform.rotation);

			Destroy (gameObject);
		}
		
	}
}
