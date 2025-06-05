using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public GameObject pauseScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true); 
        }
    }

    private void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
    }

    public void Play()
    {
        LevelManager.Instance.LoadScene("Game", "CrossFade");
    }

    public void Menu()
    {
        LevelManager.Instance.LoadScene("Menu", "CrossFade");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit(); 
    }

}
