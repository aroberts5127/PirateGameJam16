using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponDrops { SWORD, SPEAR }
public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float curHealth;

    private bool canTakeDamage;
    private float noDamageTimer;
    private float takeDamageDelay = 2.0f;
    [SerializeField]
    private WeaponDrops weaponDrops;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        canTakeDamage = true;
        noDamageTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
            Die();
        if (!canTakeDamage)
        {
            if (noDamageTimer < takeDamageDelay)
            {
                noDamageTimer += Time.deltaTime;
            }
            else
            {
                canTakeDamage = true;
                noDamageTimer = 0.0f;
            }
        }
        
    }

    public void TakeDamage()
    {
        if (!canTakeDamage)
        {
            return;
        }
        canTakeDamage = false;
        Debug.Log("Taking Damange");
        curHealth -= 1;
        
    }


    private void Die()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
