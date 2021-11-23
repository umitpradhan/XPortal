using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ApplicationQuit : MonoBehaviour
{
    

    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Quit") || CrossPlatformInputManager.GetButtonDown("Q"))
        {
            Application.Quit();
        }
    }
        
    
    
}
