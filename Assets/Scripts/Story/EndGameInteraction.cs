using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameInteraction : EnvironmentInteractable
{
    [SerializeField]
    private GameObject dialogueHolder;
    public override void Start()
    {
        base.Start();
    }

    public override void Interact(PlayerState_Player interacter)
    {
        base.Interact(interacter);
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(WaitToChangeScene());
    }

    private IEnumerator WaitToChangeScene()
    {
        while(dialogueHolder.activeSelf)
            yield return null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
