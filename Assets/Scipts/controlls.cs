using UnityEngine;
using System.Collections;

public class controlls : MonoBehaviour {

	public float ms = 5.0f;
	public float mousesensetivity = 5.0f;
	public float verticalrotation = 0.0f;
	public float updownrange = 60.0f;

	// Use this for initializations
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//rotation
		//float rotX = Input.GetAxis("Mouse X") * mousesensetivity;
		//transform.Rotate(0 , rotX , 0);

		/*verticalrotation -= Input.GetAxis("Mouse Y") * mousesensetivity;
		verticalrotation = Mathf.Clamp (verticalrotation, -updownrange, updownrange);
		Camera.main.transform.rotation = Quaternion.Euler(verticalrotation,0,0); */



		//movement
		float forwardspeed = Input.GetAxis("Vertical")* ms;
		float sidespeed = Input.GetAxis("Horizontal")* ms;
	

		Vector3 speed = new Vector3(sidespeed , 0 ,forwardspeed);

		speed = transform.rotation * speed;

		CharacterController cc = GetComponent<CharacterController>();

		cc.SimpleMove( speed );
	}
}