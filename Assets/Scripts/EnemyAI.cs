using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  // Reference to the player
    private NavMeshAgent agent;
    public float chaseRange = 10f;  // Distance at which enemy starts chasing
    public float attackRange = 2f;  // Distance at which enemy attacks
    public float attackDamage = 10f;
    public float attackRate = 1f;  // Time between attacks
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange)  // If player is within chase range
        {
            agent.SetDestination(player.position);

            if (distance <= attackRange && Time.time >= nextAttackTime)  // If within attack range
            {
                AttackPlayer();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Enemy Attacking Player!");
        // Here, you can call a PlayerHealth script to reduce health
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.takedamage(20f); // Enemy deals 20 damage
            }
        }
    }
}
