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
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        currentStaminaTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina == maxStamina) return;

        if (currentStaminaTimer < 1)
        {
            currentStaminaTimer += (1 / staminaRechargeRate) * Time.deltaTime;
            return;
        }
        currentStamina += 1;
        currentStaminaTimer = 0.0f;
    }

    public bool CheckStaminaForActionInput()
    {
        return currentStamina > 0 ? true : false;
    }


    public void SubtractStaminaForAction(iDepossess d)
    {
        currentStamina -= 1;
        if (currentStamina <= 0)
            d.depossess();
        // TODO - Handle the depossess gracefully after we us the final stamina point need to make sure the Action finishes.
    }
}
