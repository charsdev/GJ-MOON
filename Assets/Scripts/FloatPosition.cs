using UnityEngine;

public class FloatPosition : MonoBehaviour
{
    public float offset = 3;
    
    private void Update()
    {
        if(Time.timeScale == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + offset * Mathf.Sin(Time.time),
                transform.position.z);
        }
    }
}