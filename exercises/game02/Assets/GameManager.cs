using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	
	GameObject ground;
	
	 
	

	int buttonPressed = 0;
	
	// Start is called before the first frame update
	void Start()
	{
		 
		ground = GameObject.Find("Ground");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void StartGame()
	{
		buttonPressed++;

		if (buttonPressed > 0) {
			// Load level
			SceneManager.LoadScene("SampleScene");
		}
	}
}
