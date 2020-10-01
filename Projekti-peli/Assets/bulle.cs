using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulle : MonoBehaviour
{
    public int Damage;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<enemy>() != null)
           collision.gameObject.GetComponent<enemy>().TakeDamage(Damage);
        Destroy(gameObject);
    }
}
