using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;

    public void enableCrosshair()
    {
        crosshair.SetActive(false);
    }
    
    public void disableCrosshair()
    {
        crosshair.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        disableCrosshair();
    }
}