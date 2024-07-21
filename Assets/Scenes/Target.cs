using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent navMeshAgent;
    public float atleastDist;

    private void Update() {
        float distToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distToPlayer > atleastDist)
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);

        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, atleastDist);
    }
}
