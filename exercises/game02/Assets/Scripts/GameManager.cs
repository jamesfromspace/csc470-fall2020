using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static int score = 0;
	public int buttonPressed = 0;
	
	public GameObject beamPrefab;
	public GameObject stormtrooper;
    
	GameObject muzzle;
	GameObject Plane;
	
	// Start is called before the first frame update
	void Start()
	{
		muzzle = GameObject.Find("muzzle");
		Plane = GameObject.Find("Plane");
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/*public void ShootLaser()
	{
		
		Vector3 pos = new Vector3(muzzle.transform.position.x
			, muzzle.transform.position.y - 0.12f,
			muzzle.transform.position.z);
		GameObject laserBullet = Instantiate(beamPrefab, pos, muzzle.transform.rotation);
		Destroy(beamPrefab, 3f);
	}*/

	public void startGame()
	{
		
		buttonPressed++;

		if (buttonPressed < 0)
		{
			// Load game
			SceneManager.LoadScene("level");
		}

	}
}	




