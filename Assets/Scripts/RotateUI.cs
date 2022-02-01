using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public bool right;
    public float speed;

    private void Start()
    {
        speed = right ? -speed : speed;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

}
