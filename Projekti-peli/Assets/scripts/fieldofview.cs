using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldofview : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstaclemask;

    public enemy Enemy;

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindvisibleTargets();
        }
    }

    void FindvisibleTargets()
    {
        Collider[] targetsinViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsinViewRadius.Length; i++)
        {

            Transform target = targetsinViewRadius[i].transform;
            Vector3 DirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, DirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, DirToTarget, dstToTarget, obstaclemask))
                {
                    Enemy.canSeePlayer = true;
                }
                else
                {
                    Enemy.canSeePlayer = false;
                }
            }
        }
    }

    public Vector3 DirfromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
