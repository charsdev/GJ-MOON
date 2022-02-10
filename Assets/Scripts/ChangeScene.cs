using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Image imgBG;
    public AnimationCurve fadeCurve;
    public string sceneName;
    public float secondsToFadeOut;
    public bool isFadeInEnabled = false;
    
    public void Start()
    {
        if (isFadeInEnabled)
        {
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            if (imgBG != null)
            {
                imgBG.color = new Color(0.0754717f, 0.0754717f, 0.0754717f, a);
            }
            yield return 0;
        }
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    
    IEnumerator FadeOut(string scene)
    {
        float t = secondsToFadeOut;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            if (imgBG != null)
            {
                imgBG.color = new Color(0.0754717f, 0.0754717f, 0.0754717f, a);
            }
            
            yield return 0;
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physics.autoSimulation = true;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
