using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuGUI;
    [SerializeField] private bool isGamePaused = false;
    [SerializeField] private EnemyAI[] enemiesToDelete;
    public Slider musicSlider;
    public Slider sfxSlider;
    private void Start()
    {
        enemiesToDelete = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI enemy in enemiesToDelete)
        {
            Destroy(enemy.gameObject);
        }
        AudioManager.audioInstance.GetSliderValues(musicSlider, sfxSlider);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                pauseMenuGUI.SetActive(true);
                PauseGame();
            }
            else if (isGamePaused)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Physics.autoSimulation = false;
    }
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        pauseMenuGUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physics.autoSimulation = true;
    }

    public void RestartLevel()
    {
        enemiesToDelete = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI enemy in enemiesToDelete)
        {
            Destroy(enemy.gameObject);
        }
        Time.timeScale = 1;
        pauseMenuGUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physics.autoSimulation = true;
        AudioManager.audioInstance.PlayMainTheme();
        AudioManager.audioInstance.SetSliderValues(musicSlider, sfxSlider);
        SceneManager.LoadScene("TheLevel", LoadSceneMode.Single);
        
    }

    public void MainMenu()
    {
        enemiesToDelete = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI enemy in enemiesToDelete)
        {
            Destroy(enemy.gameObject);
        }
        Time.timeScale = 1;
        pauseMenuGUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Physics.autoSimulation = true;
        AudioManager.audioInstance.PlayMenuTheme();
        AudioManager.audioInstance.SetSliderValues(musicSlider, sfxSlider);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
}