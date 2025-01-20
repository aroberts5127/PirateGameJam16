using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGroup : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> waypoints;

    public List<Waypoint> GetWaypoints()
    {
        return waypoints;
    }

    public Waypoint GetWaypointWithID(int id)
    {
        foreach (var waypoint in waypoints)
        {
            if (waypoint.ID == id) return waypoint;
        }
        return waypoints[0];
    }
}
