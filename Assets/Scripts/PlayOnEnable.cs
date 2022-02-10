using UnityEngine;
using UnityEngine.Events;

public class PlayOnEnable : MonoBehaviour
{
    public UnityEvent onEnableEvent;

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }
}
