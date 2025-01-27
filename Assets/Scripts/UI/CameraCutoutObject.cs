using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraCutoutObject : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject;
    [SerializeField]
    private LayerMask wallMask;

    [SerializeField]
    private float cutoffSize = .25f;
    [SerializeField]
    private float falloffSize = 0;

    private List<GameObject> allHistObjects;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        allHistObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);

        Vector3 offset = targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, wallMask);



        for(int i = 0; i < hitObjects.Length; ++i)
        {
            if (!allHistObjects.Contains(hitObjects[i].transform.gameObject))
            {
                allHistObjects.Add(hitObjects[i].transform.gameObject);
            }
            Material[] materials = hitObjects[i].transform.GetComponent<Renderer>().materials;
            for(int m = 0; m < materials.Length; ++m)
            {
                materials[m].SetVector("_CutoffPos", Vector2.zero);
                materials[m].SetFloat("_CutoffSize", cutoffSize);
                materials[m].SetFloat("_FalloffSize", falloffSize);
            }
        }
        if (allHistObjects.Count < 0)
            return;
        foreach (GameObject obj in allHistObjects)
        {
            bool isHit = false;
            for(int i = 0;i < hitObjects.Length; ++i)
            {
                if (obj == hitObjects[i].transform.gameObject)
                    isHit = true;                   
            }
            if(!isHit)
            {
                Material[] mats = obj.GetComponent<Renderer>().materials;
                for (int m = 0; m < mats.Length; ++m) {
                    obj.GetComponent<Renderer>().materials[m].SetFloat("_CutoffSize", 0);
                    obj.GetComponent<Renderer>().materials[m].SetFloat("_FalloffSize", 0);
                }
            }
        }
    }
}
