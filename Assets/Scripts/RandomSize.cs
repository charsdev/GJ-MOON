using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = Vector3.one * Random.Range(106, 190);
        var rot = transform.localEulerAngles;
        rot.y = Random.Range(0, 360);
        transform.eulerAngles = rot;

    }

}
