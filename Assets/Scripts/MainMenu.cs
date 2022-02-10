using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
        [SerializeField] private GameObject creditsUI;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Awake()
        {
                AudioManager.audioInstance.SetMainMenuSliders(musicSlider, sfxSlider);
        }

        public void LoadLevel()
        {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Physics.autoSimulation = true;
                SceneManager.LoadScene("TheLevel", LoadSceneMode.Single);
        }

        public void PlayMusic()
        {
                AudioManager.audioInstance.PlayMainTheme();
        }
        public void Quit() 
        {
#if UNITY_EDITOR
            Debug.Log("Quitting Game");
#else
        Application.Quit();
#endif
        }
}
