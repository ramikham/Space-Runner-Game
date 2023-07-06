// Refrences:
// 1. https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    public float look_radius = 40f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = Player_Manager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);      // distance from enemy to player

        if (distance <= look_radius)            // if the player is within the enemy's look_raidus
        {
            agent.SetDestination(target.position);          // start chasing the player

            if (distance <= agent.stoppingDistance)
            {       
                Face_Target();  // face the target
            }
        }

    }

    void Face_Target()
    {
        Vector3 direction_to_target = (target.position - transform.position).normalized;
        Quaternion rotation_to_target = Quaternion.LookRotation(new Vector3(direction_to_target.x, 0, direction_to_target.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation_to_target, Time.deltaTime * 5f);                             // update 
    }

    // When in Edit mode, we can see the detection radius
    // Reference: [1]
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }
}
