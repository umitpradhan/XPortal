using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public void ScreenManager()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
}