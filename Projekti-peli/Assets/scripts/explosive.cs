using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class explosive : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    public int damage = 100;

    public GameObject explosionEffect;
    AudioSource source;
    public GameObject sound;
    public AudioClip[] clips;

    float countDown;
    bool HasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0f && !HasExploded)
        {
            Explode();
            HasExploded = true;
        }
    }

    private void Explode()
    {
         var ins = Instantiate(sound, transform.position, transform.rotation);
        source = ins.GetComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
        Destroy(ins, 5);
        var _explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(_explosion, 1f);

        Collider[] collidersToTakeDamage = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in collidersToTakeDamage)
        {
            enemy enemy = nearbyObject.GetComponentInParent<enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
