using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }    
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);

    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
