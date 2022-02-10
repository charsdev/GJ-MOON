using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Damage");
            other.GetComponent<Health>().TakeDamage(100);
        }
    }
}


