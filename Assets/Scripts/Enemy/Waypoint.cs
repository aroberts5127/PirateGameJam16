using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private int _id;
    public int ID { get { return _id; } }

    [SerializeField]
    private Vector3 position;

    private void Start()
    {
        position = transform.position;
    }


}
