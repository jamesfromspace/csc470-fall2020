using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	float speed;
	

	// This value is set in the Unity editor by dragging the Text object
	// into the slot in the inspector.
	

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
	void Update()
	{
		speed = 15.0f;
     
    	if (Input.GetKey(KeyCode.D)) {
       		transform.Translate(Vector3.right * speed * Time.deltaTime);
    	}
		if (Input.GetKey(KeyCode.A)) {
       		transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		
	}
}
