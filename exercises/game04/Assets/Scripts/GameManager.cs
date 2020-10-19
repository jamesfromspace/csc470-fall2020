using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	
	public GameObject SpherePrefab;
	public float timeRemaining = 30.0f;
	public bool timerIsRunning = false;
	
	public Text timeText;
	public Text healthText;
	public Text scoreText;

	private int score;
	private int health;

    // Start is called before the first frame update
    void Start()
    {
		// Initialize the score text to 0.
		score = 0;
		health = 100;
		HealthRemaining();
		IncreaseScore();
		timerIsRunning = true;
		
		/*for (int i = 0; i < 100; i++)
		{
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 0, z);
			float y = Terrain.activeTerrain.SampleHeight(pos) + Random.Range(10, 80);
			pos.y = y;
			GameObject Sphere = Instantiate(SpherePrefab, pos, Quaternion.identity);
			Sphere.transform.Rotate(0, Random.Range(0, 360), Random.Range(0, 360));
		}*/
    }

    // Update is called once per frame
    void Update()
    {
	    if (timerIsRunning)
	    {
		    if (timeRemaining > 0)
		    {
			    timeRemaining -= Time.deltaTime;
			    DisplayTime(timeRemaining);
		    }
		    else
		    {
			    timeRemaining = 0;
			    timerIsRunning = false;
			    SceneManager.LoadScene("GameOver");
		    }
	    }
    }

    
    void DisplayTime(float timeToDisplay)
    {
	    timeToDisplay += 1;

	    float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
	    float seconds = Mathf.FloorToInt(timeToDisplay % 60);

	    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
		
	}
    
    public void HealthRemaining()
	{
		health--;
		healthText.text = health.ToString();
	}
}
