using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations.Rigging;
using UnityEngine;

public class random_spanwer : MonoBehaviour
{
    public GameObject prefab;

    public float minTime;
    public float maxtime;

    float countdown;

    void restartTimer()
    {
        countdown = Random.Range(minTime, maxtime);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            restartTimer();
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
