using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulle : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
