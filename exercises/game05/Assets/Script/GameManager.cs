using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	
	
	public float timeRemaining = 30.0f;
	public bool timerIsRunning = false;
	
	public Text timeText;
	public Text scoreText;

	private int score;
	

    // Start is called before the first frame update
    void Start()
    {
		// Initialize the score text to 0.
		score = 0;
		//IncreaseScore();
		timerIsRunning = true;
		
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
}