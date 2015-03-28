using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// reference to camera in order to position correctly with map
	public GameObject mainCamera;

	// camera distance
	public float cameraDistance = -5.0f;
	public GameObject leftWallPrefab;
	public GameObject rightWallPrefab;
	public GameObject backgroundPrefab;

	public float fallSpeed; 

	// excludes left and right wall tile
	public float mapWidth;
	public float mapHeight;


	GameObject[,] mapArray;

	// Use this for initialization
	void Start () {

		// position cameran to center of map
		mainCamera.transform.position = new Vector3(mapWidth / 2, mapHeight / 2, cameraDistance);

		for(int y = 0; y < mapHeight; y++){
			for(int x = 0; x < mapWidth; x++){
				Instantiate (backgroundPrefab, new Vector2(x,y), backgroundPrefab.transform.rotation);
			}
		}
	

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	// spawn level tiles based on width
	void SpawnLevel() {


	}

}
