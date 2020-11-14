using System.Collections;  
using System.Collections.Generic;  
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame: MonoBehaviour 
{ 
    
    public void NextScene(string game05)
    {
        SceneManager.LoadScene("game05");
    }  
}