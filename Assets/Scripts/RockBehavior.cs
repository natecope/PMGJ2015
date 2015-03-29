using UnityEngine;
using System.Collections;

public class RockBehavior : MonoBehaviour {

	//so we can get object speed
	public LevelManager levelManager;

	//rock break particles
	public GameObject rockDestroyParticles;

	//how wide?
	public int tileWidth = 2;

	//move up or down?
	public bool moveUp;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		float moveSpeed = 0;
		Vector2 newPos = new Vector2();
		if(moveUp){
			moveSpeed = levelManager.bottomObjectsMoveSpeed;
		} else {
			moveSpeed = -levelManager.topObjectsMoveSpeed;
		}

		newPos.y = transform.position.y + moveSpeed * Time.deltaTime;
		newPos.x = transform.position.x;
		transform.position = newPos;

		if(transform.position.y > levelManager.mapHeight + 2 || 
		   transform.position.y < 0){

			Destroy(gameObject);

		}
	}



	void OnTriggerEnter2D(Collider2D other){
		
		Debug.Log ("collision detecteed from " + other.gameObject.tag);
		if(other.gameObject.tag == "Drill" || other.gameObject.tag=="Beam"){

			Instantiate(rockDestroyParticles, other.gameObject.transform.position, transform.rotation);

			Destroy (gameObject);
		}

		if(other.gameObject.tag == "Rock"){

			Instantiate(rockDestroyParticles, transform.position, transform.rotation);

			Destroy (other.gameObject);
			Destroy (gameObject);

		}
		
	}



	void OnParticleCollision(GameObject other) {
		Debug.Log (other.gameObject.tag);
	}


}
