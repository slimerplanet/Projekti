using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100;
    public float fireRate = 15;
    public bool isAutomatic;
    public float impactForce = 30;
    public float speed = 100;

    public LayerMask mask;


    public int maxammo = 15;
    private int currentAmmo;
    public float reloadTime;
    private bool isReloading;




    public Camera fpsCam;
    //public ParticleSystem muzzleflash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    private void Start()
    {
        currentAmmo = maxammo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(reload());
            return;
        }

        if (!isAutomatic)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }
    IEnumerator reload()
    {
        isReloading = true;
        Debug.Log("reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);


        currentAmmo = maxammo;
        isReloading = false;
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
        //muzzleflash.Play();

        currentAmmo--;

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

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

    }
}
