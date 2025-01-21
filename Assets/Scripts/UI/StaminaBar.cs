using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    [SerializeField]
    private Image staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.PlayerStaminaAction += StaminaListener;
    }

    private void StaminaListener(int curStamina, int maxStamina)
    {
        staminaBar.fillAmount = (float)curStamina / (float)maxStamina;
    }
    
}
