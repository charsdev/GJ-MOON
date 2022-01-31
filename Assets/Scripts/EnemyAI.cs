using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float EnemyDistance = 4.0f;
    public Animator anim;
    public GameObject explosion;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        var delta = player.transform.position - transform.position;
        var sqrMagnitude = Vector3.SqrMagnitude(delta);
        anim.SetFloat("Magnitude", sqrMagnitude);
        if (sqrMagnitude < EnemyDistance * EnemyDistance)
        {
            var newPos = transform.position + delta;
            agent.SetDestination(newPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(10);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }


}
