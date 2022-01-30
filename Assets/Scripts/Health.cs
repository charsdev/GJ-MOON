using UnityEngine.Events;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public UnityEvent onDamage;
    public UnityEvent OnDeath;
    protected new Collider2D collider;
    private bool hasCollider;
    private Action schedule;


    private void Start()
    {
        currentHealth = maxHealth;
        hasCollider = TryGetComponent<Collider2D>(out collider);
        onDamage.Invoke();

    }

    private void LateUpdate()
    {
        if (schedule != null)
        {
            schedule();
            schedule = null;
        }
    }

    public void TakeDamage(float value)
    {
        currentHealth = currentHealth > 0 ? currentHealth - value : 0;

        onDamage.Invoke();

        if (currentHealth <= 0)
        {
            Debug.Log("DEAD");

            OnDeath.Invoke(); 
        }
    }

    public void SetStateCollider(bool state)
    {
        if (hasCollider) 
            collider.enabled = state;
    }
}
