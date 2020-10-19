using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject bombPrefab;
    public Camera cam;

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
        GameObject bomb = Instantiate(bombPrefab, cam.transform.position, cam.transform.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
