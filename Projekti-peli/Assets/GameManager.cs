using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    pausemenu pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pausemenu>();
        pause.Resume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
