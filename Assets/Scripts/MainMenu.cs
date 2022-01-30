using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
        [SerializeField] private GameObject creditsUI;
        public void LoadLevel() => SceneManager.LoadScene("TheLevel", LoadSceneMode.Single);
        public void Quit() 
        {
#if UNITY_EDITOR
            Debug.Log("Quitting Game");
#else
        Application.Quit();
#endif
        }
}
