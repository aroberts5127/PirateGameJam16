using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera_WorldUI : MonoBehaviour
{
    Transform _lookTarget;
    [SerializeField]
    float _lookSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _lookTarget = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, Quaternion.LookRotation(_lookTarget.position, Vector3.up), _lookSpeed * Time.deltaTime);
    }
}
