using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
public class PingPongVariable : MonoBehaviour
{
    public Light light;

    public void Update()
    {
        if (!light) return;

        light.range = Mathf.Lerp(12, 15, Mathf.PingPong(Time.time, 1));


    }
}
