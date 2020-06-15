using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public int score;

    public Image livesDisplay;
    public Text scoreText;

    public GameObject titleScreen;

    public void UpdateLives(int currentLives)
    {
        livesDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "SCORE :" + score.ToString();
    }

    public void showTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void hideTitleScreen ()
    {
        titleScreen.SetActive(false);
        scoreText.text = "SCORE :";
    }
}
