using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

	public float destroyDelayTime;

	// Use this for initialization
	void Start () {

		StartCoroutine("DestroyAfter");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DestroyAfter(){
		
		yield return new WaitForSeconds(destroyDelayTime);
		Destroy (gameObject);
		
	}
}
