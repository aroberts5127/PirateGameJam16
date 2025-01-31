using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsGO;

    public void OnClick_StartGame()
    {
        StartCoroutine(WaitToLoadScene());
    }

    private IEnumerator WaitToLoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnClick_ShowCredits()
    {
        creditsGO.SetActive(true);
    }
    public void OnClick_HideCredits()
    {
        creditsGO.SetActive(false);
    }
}
