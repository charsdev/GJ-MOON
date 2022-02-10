using UnityEngine;

public class StopMusic : MonoBehaviour
{
    private void Awake()
    {
        AudioManager.audioInstance.StopMusic("MainTheme");
    }
}