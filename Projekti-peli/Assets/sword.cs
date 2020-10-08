using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetBool("attack", true);
        }else {
            animator.SetBool("attack", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
