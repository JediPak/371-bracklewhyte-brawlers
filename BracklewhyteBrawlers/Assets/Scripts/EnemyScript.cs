using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    private GameObject player;
    private NavMeshAgent agent;
    private Rigidbody enemyRb;
    public float speed = 3f;

    void Start()
    {

        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        enemyRb = GetComponent<Rigidbody>();
        agent.speed = speed;
    }

    void Update()
    {
        //agent.SetDestination(player.transform.position);
        Vector3 lookDirection = (player.transform.position - transform.position);//.normalized;

        enemyRb.AddForce(lookDirection * speed);


    }
}
