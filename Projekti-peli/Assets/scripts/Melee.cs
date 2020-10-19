using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] Animator animator;
    public LayerMask mask;
    public Camera fpsCam;
    public int damage = 25;
    public int range = 5;


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

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, mask))
        {
            Debug.Log(hit.transform.name);
            enemy enemy = hit.transform.GetComponentInParent<enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
