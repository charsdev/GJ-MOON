using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPosition : MonoBehaviour
{
   public float offset = 3;
    public
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + offset * Mathf.Sin(Time.time), transform.position.z);
    }
}
