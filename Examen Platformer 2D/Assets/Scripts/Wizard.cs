/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    public float protection = 50f;

    public override void TakeDamage(float amount)
    {
        if (protection > 0)
        {
            float remainingProtection = protection - amount;
            if (remainingProtection >= 0)
            {
                protection = remainingProtection;
                Debug.Log("Wizard's protection absorbed " + amount + " damage.");
                return;
            }
            else
            {
                protection = 0;
                amount -= protection;
                Debug.Log("Wizard's protection absorbed " + protection + " damage.");
            }
        }

        base.TakeDamage(amount);
    }
}
*/