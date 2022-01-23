using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        BackgroundSound.bs.setted = false;
        SceneManager.LoadScene("main");
    }
    public void ResumeGame()
    {
        if (BackgroundSound.bs != null)
            if (BackgroundSound.bs.setted)
                SceneManager.LoadScene(BackgroundSound.bs.scene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
