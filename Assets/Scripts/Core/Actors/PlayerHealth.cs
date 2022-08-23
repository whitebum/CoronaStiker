using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerHealth : HealthSystem
    {
        protected override void Reset()
        {
            base.Reset();

            maxHP = curHP = 5;

            isInvincible = false;
            invincbleTimer = 0.0f;
        }

        protected override void Awake()
        {
            base.Awake();

            isInvincible = false;
            invincbleTimer = 0.0f;
        }

        private void Update()
        {
            if (isInvincible)
            {
                if ((invincbleTimer -= Time.deltaTime) < 0.0f)
                {
                    isInvincible = false;
                    invincbleTimer = 0.0f;
                }
            }

            if (Input.GetKeyDown(KeyCode.KeypadMinus)) ;
        }
    }
}