using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBarImg;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.PlayerHealthAction += HealthListener;
    }



    private void HealthListener(int curHealth, int maxHealth)
    {
        if (healthBarImg != null)
        {
            healthBarImg.fillAmount = (float)curHealth / (float)maxHealth;
        }
    }
}
