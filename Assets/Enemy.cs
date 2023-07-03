using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Movement>().transform;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }

}