using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;

    public LayerMask whatIsGround, whatIsPlayer;

    //petroling of enemy
    public Vector3 walkPoint;
    bool walkPointset;
    public float walkPointRange;

    //State
    public float sightRange ,attackRange;

    public bool isInSightRange, isInAttackRange;


    //Attack
    public bool alreadyAttacked;
    public float timeBetweenAttacks;


    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check sight range and attack range
        isInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        isInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isInSightRange && !isInAttackRange) Patrol();
        if (isInSightRange && !isInAttackRange) chase();
        if (isInSightRange && isInAttackRange) attack();

    }

    void Patrol()
    {
        Debug.Log("you are out of range");

        if (!walkPointset) SearchWorkPoint();
        if (walkPointset) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointset = false;

    }

    void SearchWorkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointset = true;

    }
    void chase()
    {
        Debug.Log("you are in chase range");

        agent.SetDestination(Player.position);

    }

    void attack()
    {
        Debug.Log("you are in attack range");

        agent.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }








}
