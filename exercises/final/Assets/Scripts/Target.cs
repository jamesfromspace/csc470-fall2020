using UnityEngine;
using System.Collections;
using TMPro;

public class Target : MonoBehaviour {

    //GameManager gm;
    public int currentHealth = 3;

    
    void Start()
    {
      
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
            
        }
    }
}

