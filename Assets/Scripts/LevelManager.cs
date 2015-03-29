using UnityEngine;
using System.Collections;
[System.Serializable]
public class LevelManager : MonoBehaviour {


	public GameObject[] bottomObjects; 
	public float spawnDelaySeconds;
	// reference to camera in order to position correctly with map
	public GameObject mainCamera;

	// camera distance
	public float cameraDistance = -5.0f;
	public GameObject leftWallPrefab;
	public GameObject rightWallPrefab;
	public GameObject backgroundPrefab;
	public GameObject backgroundLighting;

	public float backgroundMoveSpeed;
	public float wallMoveSpeed;
	public float bottomObjectsMoveSpeed;

	// excludes left and right wall tile
	public int mapWidth;
	public int mapHeight;
	// left and right wall widths
	public int wallWidth;

	GameObject[,] mapArray;

	// Use this for initialization
	void Start () {

		// position cameran to center of map
		mainCamera.transform.position = new Vector3((mapWidth / 2)+1, (mapHeight / 2) + 1, cameraDistance);

		SpawnLevel();
		StartObjectSpawner();
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void StartObjectSpawner(){

		StartCoroutine("objectRowSpawner");

	}

	void FixedUpdate(){
		ScrollLevel();
	}

	// spawn level tiles based on width
	void SpawnLevel() {

		// Initialize map array
		mapArray = new GameObject[mapWidth,mapHeight];

		for(int y = 0; y < mapHeight; y++){
			for(int x = 0; x < mapWidth; x++){

				if(x < wallWidth){

					// stuff left wall map objects into array
					mapArray[x,y] = Instantiate (leftWallPrefab, new Vector2(x,y), leftWallPrefab.transform.rotation) as GameObject;

				} else if (x > (mapWidth-wallWidth)){

					// stuff right wall map objects into array
					mapArray[x,y] = Instantiate (rightWallPrefab, new Vector2(x,y), rightWallPrefab.transform.rotation) as GameObject;

				} else {

					// stuff wall map objects into array
					mapArray[x,y] = Instantiate (backgroundPrefab, new Vector2(x,y), backgroundPrefab.transform.rotation) as GameObject;

				}

			}
		}
		
	}


	void ScrollLevel(){

		float tileMoveSpeed = 0;

		for(int y = 0; y < mapHeight; y++){
			for(int x = 0; x < mapWidth; x++){

				if(x<wallWidth || x> (mapWidth-wallWidth)) {
					tileMoveSpeed = wallMoveSpeed;
				} else {
					tileMoveSpeed = backgroundMoveSpeed;
				}

				Vector2 newPos = new Vector2();

				// move tile position
				newPos.y = mapArray[x,y].transform.position.y + tileMoveSpeed * Time.deltaTime/2;
				newPos.x = mapArray[x,y].transform.position.x;

				// reset to bottom if hit top of map
				if(Mathf.Round (mapArray[x,y].transform.position.y) >= mapHeight){
					newPos.y = -0.4f;

					if(x<wallWidth || x> (mapWidth-wallWidth)) {
						newPos.y = 0f;
					} else {
						newPos.y = -0.45f;
					}
				}

				// update object position
				mapArray[x,y].transform.position = newPos;
				
				
			}
		}

	}


	IEnumerator objectRowSpawner(){
		int toSkip = 0;
		while(true){
			yield return new WaitForSeconds(spawnDelaySeconds);

			//spawn row of objects. Randomize
			for(int x = 0 + wallWidth; x < mapWidth - wallWidth; x++){


				if(toSkip == 0){
					GameObject objectToSpawn = bottomObjects[(int)Random.Range (0, bottomObjects.Length)];
					GameObject objectSpawned = Instantiate (objectToSpawn, new Vector2(x,0), objectToSpawn.transform.rotation) as GameObject;

					toSkip = objectSpawned.GetComponent<RockBehavior>().tileWidth - 1;
				} else {
					toSkip--;
				}

			}
		}
	}



}
