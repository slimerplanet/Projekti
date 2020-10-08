using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator animator;
    public int damage;
    [SerializeField] private bool attacking;
    private void Start()
    {
        attacking = false;
        animator.SetBool("attack", false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetBool("attack", true);
            attacking = true;
        }else if(Input.GetKeyUp(KeyCode.Mouse0)){
            animator.SetBool("attack", false);
            Invoke("setattackFalse", 0.25f);
        }
    }

    void setattackFalse() => attacking = false;


}
