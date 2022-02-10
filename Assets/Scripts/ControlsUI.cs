using UnityEngine;

public class ControlsUI : MonoBehaviour
{
    [SerializeField] private GameObject ControlInfoUION;
    [SerializeField] private GameObject ControlInfoUIOFF;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (ControlInfoUION.activeInHierarchy)
            {
                ControlInfoUION.SetActive(false);
                ControlInfoUIOFF.SetActive(true);
            }
            else
            {
                ControlInfoUIOFF.SetActive(false);
                ControlInfoUION.SetActive(true);
            }
        }
    }
}