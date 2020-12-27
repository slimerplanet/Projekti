using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    [Header("stats")]
    public int damage = 10;
    public float range = 100;
    public float fireRate = 15;
    public bool isAutomatic;
    public float impactForce = 30;
    public float speed = 100;
    public int maxammo = 15;
    public float reloadTime;


    
    


    [Header("refrences")]
    
    pausemenu menu;
    public Animator animator;
    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public LayerMask mask;
    public AudioSource source;
    public GameObject[] bulletHoles;


    private float nextTimeToFire = 0f;
    private int currentAmmo;
    private bool isReloading;



    private void Start()
    {
        menu = FindObjectOfType<pausemenu>();
        currentAmmo = maxammo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    void Update()
    {


        if (isReloading || menu.paused)
            return;

        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Inspect");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }

        if (currentAmmo <= 0 && !isReloading)
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
        source.Play();
        muzzleflash.Play();

        currentAmmo--;
        animator.SetTrigger("Shoot");

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, mask))
        {
            Debug.Log(hit.transform.name);
            enemy enemy = hit.transform.GetComponentInParent<enemy>();
            if (enemy != null)
            {
                Debug.Log("zombie has " + enemy.Health + " health");
                enemy.TakeDamage(damage);
            }
            var _hole = Instantiate(bulletHoles[Random.Range(0, bulletHoles.Length)], hit.point, Quaternion.LookRotation(hit.normal));
            _hole.transform.parent = hit.collider.transform;
            Destroy(_hole, 60);
        }

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

    }
}
