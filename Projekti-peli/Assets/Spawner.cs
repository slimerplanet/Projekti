using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public bool spawnOnStart;

    public void spawn()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Instantiate(objects[i], transform.position, transform.rotation);
        }
    }

    private void Start()
    {
        if (spawnOnStart)
            spawn();
    }
}
