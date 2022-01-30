using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    bool isPaused = false;
    public int score;
    public int finalScore = 1;
    public bool winGame = false;
    public bool isDay;
    private void Awake()
    {
        if (GameManagerInstance == null)
        {
            GameManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused == true)
        {
            ContinueGame();
        }

       

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
