using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{    
    public AudioListener audioListener;
    public EventSystem eventSystem;
    public GameObject guideScreenUI;
    public GameObject mainMenuUI;
    public void PlayGame()
    {
        audioListener.enabled = false;
        eventSystem.enabled = false;
        SceneManager.LoadScene(1);
    }

    public void Guide() {
        guideScreenUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void Back() {
        guideScreenUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
