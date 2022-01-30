using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuGUI;
    [SerializeField] private bool isGamePaused = false;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                //Time.timeScale = 0;
                pauseMenuGUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Physics.autoSimulation = false;
            }
            else
            {
                //Time.timeScale = 1;
                pauseMenuGUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Physics.autoSimulation = true;
            }
        }
    }
    public void RestartLevel() => SceneManager.LoadScene("TheLevel", LoadSceneMode.Single);
    public void MainMenu() => SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
}