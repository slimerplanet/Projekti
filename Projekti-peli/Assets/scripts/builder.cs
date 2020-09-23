using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class builder : MonoBehaviour
{
    [SerializeField] GameObject TowerPrefab;
    [SerializeField] Camera cam;
    [SerializeField] int BuildDistance;
    [SerializeField] LayerMask PlacableArea;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, BuildDistance, PlacableArea))
            {
                GameObject  obj = Instantiate(TowerPrefab, hit.point, Quaternion.identity);

            }
        }
    }
}
