using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDCanvas : MonoBehaviour
{
    public Slider hpbar;
    public TextMeshProUGUI textLife;
    public Slider shinebar;



    public void UpdateCurrentHP(Health health)
    {
        textLife.text = $"{health.currentHealth} / {health.maxHealth}";
        Debug.Log(health.currentHealth / health.maxHealth);
        hpbar.value = health.currentHealth / health.maxHealth;
    }
}
