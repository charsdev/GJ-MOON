using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public void SetLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
