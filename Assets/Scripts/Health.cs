using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image fillBar;
    public float health;

    

    public void LoseHealth(float value)
    {      
        if (health <= 0)
            return;
       
        health -= value;
        Debug.Log(health);
       
        fillBar.fillAmount = health / 100;
        
        if (health <= 0)
        {
            //health = 100.0f;
            FindObjectOfType<LifeCount>().LoseLife();           
        }
    }    
        
}