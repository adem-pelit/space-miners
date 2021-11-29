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
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }


}
