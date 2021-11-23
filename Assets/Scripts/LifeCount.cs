using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    

    public void LoseLife()
    {        
        if (livesRemaining == 0)
            return;        
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if (FindObjectOfType<Health>().health <= 0)
        {
            FindObjectOfType<Health>().fillBar.fillAmount = 1;
            FindObjectOfType<Health>().health = 100;
        }
        
                     

        if (livesRemaining == 0)
        {
            FindObjectOfType<GameRestartScreen>().Revive();
        }
    }

}