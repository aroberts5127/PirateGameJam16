using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderFarm : MonoBehaviour
{
    public List<GameObject> renderFarms;
    private List<int> activeRenderFarmIDs;

    private void Start()
    {
        activeRenderFarmIDs = new List<int>();
    }

    public void ActivateRenderFarmByID(int id)
    {
        renderFarms[id].SetActive(true);
        activeRenderFarmIDs.Add(id);
    }

    public void DeactivateAllRenderFarms()
    {
        foreach(int id in activeRenderFarmIDs)
        {
            renderFarms[id].SetActive(false);
        }
        activeRenderFarmIDs.Clear();
    }
}
