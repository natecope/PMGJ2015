using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {
	public float Speed = 30.0f;
	public  int TTL;
	// Use this for initialization
	void Start () {
		StartCoroutine(TTLDestroy());
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);
	}


	void TTLDestroy(){
	
	}
}
