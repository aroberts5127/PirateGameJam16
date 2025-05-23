using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyDetection))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyDetection fov = (EnemyDetection)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.raycastDistance);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.viewAngle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.viewAngle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.raycastDistance);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.raycastDistance);

        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.playerRef.position);
        }
    }


    private Vector3 DirectionFromAngle(float eulary, float angleInDegrees)
    {
        angleInDegrees += eulary;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees* Mathf.Deg2Rad));
    }
}
