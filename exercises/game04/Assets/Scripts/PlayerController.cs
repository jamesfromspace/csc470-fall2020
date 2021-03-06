﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;

	public GameObject CapsulePrefab;
	
	float speed = 5;
	float maxSpeed = 50;
	float forwardSpeed = 5;
	float pitchSpeed = 80;
	float pitchModSpeedRate = 8f;
	float rollSpeed = 160;
	
    // Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		// Rotate the plane based on input.
		float xRot = vAxis * pitchSpeed * Time.deltaTime;
		float yRot = hAxis * rollSpeed / 4 * Time.deltaTime;
		float zRot = -hAxis * rollSpeed * Time.deltaTime;
		transform.Rotate(xRot, yRot, zRot, Space.Self);

		// Compute a modifier (forwardSpeed) based on if the plane is looking up or down.
		// If the y value of the tranform's forward is positive, we know we are looking up, 
		// if it is negative, we know we are looking down.
		//forwardSpeed += -transform.forward.y * pitchModSpeedRate * Time.deltaTime;
		// Make sure we never to too fast and that forwardSpeed never goes below zero.
		forwardSpeed = Mathf.Clamp(forwardSpeed, 0, 50f);

		// Move forward as modified by forwardSpeed and speed.
		transform.Translate(transform.forward * speed * forwardSpeed * Time.deltaTime, Space.World);

		// If we ever go too slow, turn on the gravity on the rigid body so that the plane falls.
		/*if (forwardSpeed <= 0.1f) {
			rb.isKinematic= false;
			rb.useGravity = true;
		}
*/
		// Make sure we never go below the ground. First, we find out what the height of the terrain is at
		// the position the plane is in. If the plane's y position is below that position, we know we have gone
		// too low. In the if statement, we simply place the plane at the height of the terrain.
		// But this is where you could have the plane crash, or have it slow down, or something.
		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
		if (transform.position.y < terrainHeight) {
			transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
		}

	
		if (Input.GetKeyDown(KeyCode.Space)) {
			GameObject Capsule = Instantiate(CapsulePrefab, transform.position + transform.forward * 5, Quaternion.identity);
			Rigidbody CapsuleRB = Capsule.GetComponent<Rigidbody>();
			CapsuleRB.AddForce(transform.forward * 15000);
			Destroy(Capsule, 5);
		}
		
    	// Position the camera behind and above the player.
		Vector3 cameraPosition = transform.position - transform.forward * 30 + Vector3.up * 15;
		Camera.main.transform.position = cameraPosition;
		Vector3 lookAtPos = transform.position + transform.forward * 8;
		
		// Rotate the camera so that it looks always in front of the plane.
		Camera.main.transform.LookAt(lookAtPos, Vector3.up);
	}

}
