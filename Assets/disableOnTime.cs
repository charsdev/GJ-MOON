using UnityEngine;

public class disableOnTime : MonoBehaviour
{
    [SerializeField] private float seconds = 5;
    private float secondsClone = 5;

    private void Awake()
    {
        secondsClone = seconds;
    }

    private void Update()
    {
        seconds -= 1 * Time.deltaTime;
        if (seconds < 1)
        {
            seconds = secondsClone;
            gameObject.SetActive(false);
        }
    }
}