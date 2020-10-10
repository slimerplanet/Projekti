using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;
    public AudioClip[] Sounds;
    public AudioSource source;

    [SerializeField] int range;

    public int damage;
    [SerializeField] private bool attacking;
    private void Start()
    {
        attacking = false;
        animator.SetBool("attack", false);
    }
     private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !attacking) {
            attacking = true;
            Attack();
        }

        if(attacking)
            animator.SetBool("attack", true);
        else
            animator.SetBool("attack", false);
    }

    public void Attack()
    {
        source.clip = Sounds[Random.Range(0, Sounds.Length)];
        source.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, mask))
        {
            print(hit.collider.name);
            var obj = hit.collider.gameObject;
            if(obj.GetComponent<enemy>() != null)
            {
                obj.GetComponent<enemy>().TakeDamage(damage);
            }
        }
    }

    //moi
}
