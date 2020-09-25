﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    [Header("shooting")]
    public Transform gunPoint;
    public GameObject Bullet;
    public float speed;

    [Header("aiming")]
    public Transform gun;
    private GameObject[] multipleEnemys;
    public Transform closestEnemy;

    private void Start()
    {
        closestEnemy = null;
        InvokeRepeating("shoot", 0.5f, 0.5f);
    }

    private void Update()
    {
        Vector3 direction = getClosestenemy().position - gun.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        gun.rotation = rotation;
    }
    public void shoot()
    {
        GameObject _bullet = Instantiate(Bullet, gunPoint.position, gunPoint.rotation);
        _bullet.GetComponent<Rigidbody>().velocity = gunPoint.forward * speed;

    }

    public Transform getClosestenemy()
    {
        multipleEnemys = GameObject.FindGameObjectsWithTag("Enemy");
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
