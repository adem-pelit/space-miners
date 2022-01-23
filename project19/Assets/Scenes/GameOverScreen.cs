using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    /*  public Text pointsText;
     public void Setup(int score)
      {

          gameObjebct.SetActive(true);
          pointsText.text = score.ToString() + "POINTS";
      }
    */
    public TextMeshProUGUI text;
    public void Start()
    {
        text.text = (int)Main.main.zaman + " Saniyede Tamamlandi!\nScore: " + Main.main.score;
        BackgroundSound.sound(0);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }


}
