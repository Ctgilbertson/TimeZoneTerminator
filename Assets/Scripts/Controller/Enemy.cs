
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        //setting the target of the enemy to the player object
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        //distance from enemy to player(target)
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            //set the enemy to track the player object around
            agent.SetDestination(target.position);
        }
        Debug.Log(agent.stoppingDistance);
        if(distance <= agent.stoppingDistance){

            //attack and face target
            FaceTarget();

        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(this.gameObject);

    }

    void FaceTarget(){

        //get direction to target
        Vector3 direction = (target.position - transform.position).normalized;
        //rotation to point to target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //Update enemy rotation to point in the right way using smoothing
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1);
    }

    void OnDrawGizmosSelected(){
        //Show the radius of target for the enemy looking for player
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Text"); 
    }
}
