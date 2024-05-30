using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;
    public TMP_Text hp;
    float viata = 100f;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void TakeDamage(float damage)
    {
        viata = damage;
        hp.text = "HP: " + viata.ToString();
    }
}
