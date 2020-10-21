using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class tower : MonoBehaviour
{
    [Header("shooting")]
    [SerializeField] Transform gunPoint;
    [SerializeField] LayerMask mask;
    [SerializeField] float speed;
    [SerializeField] int Damage = 25;
    [SerializeField] ParticleSystem muzzle;
    [SerializeField] float fireRate;
    float nextTimeToShoot;




    [Header("aiming")]
    [SerializeField] Transform rotationaxis;
    private GameObject[] multipleEnemys;
    [SerializeField] Transform closestEnemy;
    [SerializeField] float range = 10;

    private void Start()
    {
        nextTimeToShoot = fireRate;
        closestEnemy = null;
        


    }

    private void Update()
    {
        nextTimeToShoot -= Time.deltaTime;
        if(nextTimeToShoot <= 0)
        {
            nextTimeToShoot = fireRate;
            shoot();
        }

        if (getClosestenemy() == null)
        {
            return;
        }
        if (Vector3.Distance(getClosestenemy().position, transform.position) > range)
        {
            return;
        }


        Vector3 direction = getClosestenemy().position - gunPoint.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotationaxis.rotation = rotation;
    }
    public void shoot()
    {
        muzzle.Play();

        RaycastHit hit;
        if (Physics.Raycast(gunPoint.transform.position, gunPoint.transform.forward, out hit, range, mask))
        {
            
            var obj = hit.collider.gameObject;
                      
            if (obj.GetComponent<enemy>() != null)
            {
                obj.GetComponentInParent<enemy>().TakeDamage(Damage);
                Debug.Log("hit");               
            }
        }

    }

    public Transform getClosestenemy()
    {
        multipleEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (multipleEnemys == null)
            return null;

        float closestDisctance = Mathf.Infinity;
        Transform trans = null;
        foreach(GameObject go in multipleEnemys)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestDisctance)
            {
                closestDisctance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }
}
