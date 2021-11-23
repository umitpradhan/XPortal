using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestartScreen : MonoBehaviour
{
    public GameObject reviveWindow;

    public void Revive()
    {
        reviveWindow.SetActive(true);
    }

}
