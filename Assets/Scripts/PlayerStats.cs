using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    public int currentStamina;
    [SerializeField]
    protected int maxStamina;
    [SerializeField]
    protected float staminaRechargeRate;
    protected float currentStaminaTimer;

    [SerializeField]
    protected int currentHealth;
    [SerializeField]
    protected int maxHealth;
    public static event Action<int, int> PlayerHealthAction;
    public static event Action<int, int> PlayerStaminaAction;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentStaminaTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }

        if (currentStamina == maxStamina) return;

        if (currentStaminaTimer < 1)
        {
            currentStaminaTimer += (1 / staminaRechargeRate) * Time.deltaTime;
            return;
        }
        currentStamina += 1;
        PlayerStaminaAction?.Invoke(currentStamina, maxStamina);
        currentStaminaTimer = 0.0f;

        
    }

    public bool CheckStaminaForActionInput()
    {
        return currentStamina > 0 ? true : false;
    }


    public void SubtractStaminaForAction(iDepossess d)
    {
        currentStamina -= 1;
        currentStaminaTimer = 0.0f;
        if (currentStamina <= 0)
            d.depossess();
        // TODO - Handle the depossess gracefully after we us the final stamina point need to make sure the Action finishes.
        PlayerStaminaAction?.Invoke(currentStamina, maxStamina);
    }

    private void TakeDamage()
    {
        currentHealth -= 1;
        PlayerHealthAction?.Invoke(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Is Dead");
        currentHealth = maxHealth;
        PlayerHealthAction?.Invoke(currentHealth, maxHealth);
        //Revive Probably needs to happen via Menu? Pressing a ressurect button will help the player control pace of play.
    }
}
