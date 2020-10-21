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
    public bool hasReachedBase;
    public Animator animator;
    public Behaviour[] componentstoDisableOnDeath;
    void Start()
    {
        Base = FindObjectOfType<baseScript>();
        if(Base != null)
            agent.SetDestination(Base.points[UnityEngine.Random.Range(0, Base.points.Length)].position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Base == null)
        {
            agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
        }

        animator.SetFloat("speed", agent.velocity.magnitude);

        if (Health <= 0)
            Die();

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            hasReachedBase = true;
        }
        else
        {
            hasReachedBase = false;
        }

        
        animator.SetBool("Attacking", hasReachedBase);
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
