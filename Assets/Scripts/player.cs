using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	int Health;

	public int playerNumber;
	public LevelManager levelManager;
	public GameObject weaponBallistic;
	public GameObject Player;
	public  Transform FiringPoint;
	private float horizontalInput;
	private float verticalInput;
	private Vector3 newPos = new Vector3();
	public float movementSpeed = 100f;
	public float movementDamp = .05f;
	public int weaponTimer;
	private float dampVelocityY=0.0f;
	private float dampVelocityX=0.0f;
	private	ParticleSystem Ballistics;
	private bool weaponFired;
	private int _weaponTimer;
	// Use this for initialization
	void Start () {
		Health = 100;

		transform.position = new Vector3((levelManager.mapWidth / 2)+1, (levelManager.mapHeight / 2) + 1, 0);
		newPos = transform.position;

		_weaponTimer = weaponTimer;
	}

	void fireWeapon(){

			Instantiate(weaponBallistic, FiringPoint.position, FiringPoint.rotation);

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1") || Input.GetKeyUp(KeyCode.Joystick2Button0)){
			
			if(playerNumber == 2) {

				fireWeapon();	

			}
		}
		
		if(weaponFired){
			if(_weaponTimer==0)
			{
				Ballistics.enableEmission = false;
				weaponFired = false;
				_weaponTimer = weaponTimer; 
			}
			_weaponTimer--;
			
		}

		if(transform.localPosition.x >= levelManager.wallWidth && transform.localPosition.x <= (levelManager.mapWidth - levelManager.wallWidth)-1){ 
			if(playerNumber==1)
				playerOneUpdate();
			else
				playerTwoUpdate();
			
		}




	 }

	void playerOneUpdate(){
		if(Input.GetAxisRaw("Horizontal") == 0){
			horizontalInput = Mathf.SmoothDamp(horizontalInput, 0.0f, ref dampVelocityX, movementDamp);
			newPos.x += horizontalInput * movementSpeed * Time.deltaTime;
		}
		else{
			newPos.x += Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
			horizontalInput = Input.GetAxisRaw ("Horizontal");
		}
		if(Input.GetAxisRaw("Vertical") == 0){
			verticalInput = Mathf.SmoothDamp(verticalInput, 0.0f, ref dampVelocityY, movementDamp);
			newPos.y += verticalInput * movementSpeed * Time.deltaTime;
		}
		else{
			newPos.y += Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
			verticalInput = Input.GetAxisRaw ("Vertical");
		}
		
		if(newPos.x < levelManager.wallWidth) {
			newPos.x = levelManager.wallWidth;
		}
		if(newPos.x > (levelManager.mapWidth - levelManager.wallWidth)-1){
			newPos.x = (levelManager.mapWidth - levelManager.wallWidth)-1;
		}
		//apply new position
		transform.localPosition = newPos;
		
	}
	
	void playerTwoUpdate(){
		if(Input.GetAxisRaw("HorizontalP2") == 0){
			horizontalInput = Mathf.SmoothDamp(horizontalInput, 0.0f, ref dampVelocityX, movementDamp);
			newPos.x += horizontalInput * movementSpeed * Time.deltaTime;
		}
		else{
			newPos.x += Input.GetAxisRaw("HorizontalP2") * movementSpeed * Time.deltaTime;
			horizontalInput = Input.GetAxisRaw ("HorizontalP2");
		}
		if(Input.GetAxisRaw("Vertical") == 0){
			verticalInput = Mathf.SmoothDamp(verticalInput, 0.0f, ref dampVelocityY, movementDamp);
			newPos.y += verticalInput * movementSpeed * Time.deltaTime;
		}
		else{
			newPos.y += Input.GetAxisRaw("VerticalP2") * movementSpeed * Time.deltaTime;
			verticalInput = Input.GetAxisRaw ("VerticalP2");
		}
		
		if(newPos.x < levelManager.wallWidth) {
			newPos.x = levelManager.wallWidth;
		}
		if(newPos.x > (levelManager.mapWidth - levelManager.wallWidth)-1){
			newPos.x = (levelManager.mapWidth - levelManager.wallWidth)-1;
		}
		//apply new position
		transform.localPosition = newPos;
		
	}
}

