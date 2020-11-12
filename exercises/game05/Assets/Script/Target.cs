using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    
    public int currentHealth = 3;

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