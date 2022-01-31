using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuGUI;
    [SerializeField] private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                isGamePaused = true;
                Time.timeScale = 0;
                pauseMenuGUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Physics.autoSimulation = false;
            }
            else if (isGamePaused)
            {
                isGamePaused = false;
                Time.timeScale = 1;
                pauseMenuGUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Physics.autoSimulation = true;
            }
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        pauseMenuGUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Physics.autoSimulation = true;
        SceneManager.LoadScene("TheLevel", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenuGUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Physics.autoSimulation = true;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
}