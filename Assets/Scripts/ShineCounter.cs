using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShineCounter : MonoBehaviour
{
    public Slider shineSlider;
    public int Threshold = 10;

    public void SumShine()
    {
        Inventory.Instance.shines = (Inventory.Instance.shines >= Threshold) ? Threshold : Inventory.Instance.shines + 1;
        shineSlider.value = (float)Inventory.Instance.shines / (float)Threshold;
    }

    public void UpdateShines(int shines)
    {
        Inventory.Instance.shines = shines;
        shineSlider.value = shines / (float)Threshold;
    }
   

}
