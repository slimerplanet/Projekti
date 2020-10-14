using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
        }

    }

    void attack()
    {
        animator.SetTrigger("attack");
    }
}
