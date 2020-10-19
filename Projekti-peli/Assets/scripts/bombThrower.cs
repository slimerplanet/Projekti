using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject bombPrefab;
    public Transform spawnpoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            throwBomb();
        }
    }

    private void throwBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(spawnpoint.transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
