using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public CharacterController player;
    public GameObject gameOverMenuUI;
    public GameObject playerObject;
    public GameObject score;

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        playerObject.SetActive(false);
        score.SetActive(false);
    }

    public void TryAgaintButton ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenutButton ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
