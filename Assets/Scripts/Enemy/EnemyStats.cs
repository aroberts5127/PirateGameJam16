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
    [SerializeField]
    private WeaponDrops weaponDrops;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
            Die();
    }


    private void Die()
    {
        //drop weapon object
        //visually remove object
        //Discard this object either with Destory or Back to pool
    }
}
