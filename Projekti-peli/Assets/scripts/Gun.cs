using UnityEngine;

public class Gun : MonoBehaviour
{
   public int damage = 10;
   public float range = 100f;

   public Camera fpsCam;
   public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot ()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            enemy target = hit.transform.GetComponent<enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
