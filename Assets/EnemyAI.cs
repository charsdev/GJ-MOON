using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent _agent;
    public GameObject player;
    public float EnemyDistance = 4.0f;
   
    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        var delta = player.transform.position - transform.position;
        var sqrMagnitude = Vector3.SqrMagnitude(delta);

        if (sqrMagnitude < EnemyDistance * EnemyDistance)
        {
            var newPos = transform.position + delta;
            _agent.SetDestination(newPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(20);
            gameObject.SetActive(false);
        }
    }


}
