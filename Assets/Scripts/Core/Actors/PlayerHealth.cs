using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerHealth : HealthSystem
    {
        [SerializeField] private bool isShield;

        public sealed override void TakeDamage(float damage)
        {
            if (!isInvincible || !isDead)
            {
                if (isShield)
                {
                    isShield = false;

                    SetInvincible(6.0f);
                }
                else
                {
                    var temp = curHP - damage;

                    if (temp <= 0.0f)
                    {
                        curHP = 0.0f;
                        isDead = true;

                        if (deadParam != null)
                            animator?.SetTrigger(deadParam);
                    }
                    else
                    {
                        curHP = temp;

                        SetInvincible(6.0f);

                        if (hurtParam != null && healthParam != null)
                        {
                            animator?.SetTrigger(hurtParam);
                            animator?.SetFloat(healthParam, curHP);
                        }
                    }
                }
            }
        }
    }
}