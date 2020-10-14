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
        agent.SetDestination(Base.points[UnityEngine.Random.Range(0, Base.points.Length)].position);
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
}
