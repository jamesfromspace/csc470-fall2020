using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
		GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
    	gm = GameObject.Find("GameManagerObj").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag("sphere"))
		{
			Debug.Log("collided");
			Destroy(other.gameObject);
			SceneManager.LoadScene("GameOver");
			//gm.IncreaseScore();
			//gm.HealthRemaining();
		}
	}
}
