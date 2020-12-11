using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    baseScript Base;
    public int Health = 100;
    bool hasReachedtarget;
    public Animator animator;
    public Behaviour[] componentstoDisableOnDeath;
    public float attackDelay = 1;
    public int damage = 25;
    float countdown;

    public bool canSeePlayer;

    void Start()
    {
        countdown = attackDelay;
        Base = FindObjectOfType<baseScript>();
        if(Base != null)
            agent.SetDestination(Base.points[UnityEngine.Random.Range(0, Base.points.Length)].position);
        
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
                if(Base == null)
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
                }
            }
        }


        if(Base == null)
        {
            agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
        }

        animator.SetFloat("speed", agent.velocity.magnitude);

        if (Health <= 0)
            Die();

        if (agent.remainingDistance <= agent.stoppingDistance && agent != null)
        {
            hasReachedtarget = true;
        }
        else
        {
            hasReachedtarget = false;
        }

        

        
        animator.SetBool("Attacking", hasReachedtarget);
    }

    private void Die()
    {
        for (int i = 0; i < componentstoDisableOnDeath.Length; i++)
        {
            componentstoDisableOnDeath[i].enabled = false;
        }

        Destroy(gameObject, 5f);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
}
