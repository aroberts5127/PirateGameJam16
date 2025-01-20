using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageDetector : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Enemy")
            return;
        collision.GetComponentInParent<EnemyGraphicsParent>().scriptParent.GetComponent<EnemyStats>().TakeDamage();//ewww
    }
}
