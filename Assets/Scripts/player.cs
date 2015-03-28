using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	int Health;

	public GameObject weaponBallistic;
	public GameObject Player;
	public  Transform FiringPoint;
	private float horizontalInput;
	private float verticalInput;
	private Vector3 newPos = new Vector3();
	public float movementSpeed = 100f;
	public float movementDamp = .05f;
	private float dampVelocityY=0.0f;
	private float dampVelocityX=0.0f;


	// Use this for initialization
	void Start () {
		Health = 100;
	}

	void fireWeapon(){
		Instantiate(weaponBallistic, FiringPoint.position , FiringPoint.rotation);
		

	}

	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Joystick1Button0)){
		   fireWeapon();	
		}
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

		//apply new position
		transform.localPosition = newPos;

	 }
}
