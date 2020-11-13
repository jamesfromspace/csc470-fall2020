using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    GameManager gm;
    public int currentHealth = 3;
    
    void Start()
    {
        gm = GameObject.Find("GameManagerObj").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damageAmount)
    {
        
        currentHealth -= damageAmount;

        //Destroy target 
        if (currentHealth <= 0) 
        {
            
            gameObject.SetActive (false);
            gm.IncreaseScore();
        }
    }
}