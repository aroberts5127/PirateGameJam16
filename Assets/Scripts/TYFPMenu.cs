using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TYFPMenu : MonoBehaviour
{
    public void OnClick_ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
