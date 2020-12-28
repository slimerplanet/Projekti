using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float Health = 100;
    bool hasReachedtarget;
    public Animator animator;
    public Behaviour[] componentstoDisableOnDeath;
    public float attackDelay = 1;
    public float damage = 25;
    float countdown;

    public bool canSeePlayer;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasReachedtarget)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = attackDelay;
                
                
                    GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
                
            }
        }


        if(canSeePlayer && !hasReachedtarget)
        {
            agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
        }

        animator.SetFloat("speed", agent.velocity.magnitude);

        if (Health <= 0)
            Die();
              
        animator.SetBool("Attacking", hasReachedtarget);
    }

    private void Die()
    {
        for (int i = 0; i < componentstoDisableOnDeath.Length; i++)
        {
            componentstoDisableOnDeath[i].enabled = false;
        }

        Destroy(gameObject, 6f);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            hasReachedtarget = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasReachedtarget = false;
        }
    }
}
