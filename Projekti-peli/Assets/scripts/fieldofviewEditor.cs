using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(fieldofview))]
public class fieldofviewEditor : Editor
{
    private void OnSceneGUI()
    {
        fieldofview fow = (fieldofview)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirfromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirfromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

    }
}
