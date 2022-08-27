using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class VirusHealth : HealthSystem
    {
        protected override void Reset()
        {
            base.Reset();
        }

        protected override void Awake()
        {
            base.Awake();
        }

        public void GetInvincible(float time = 6.0f)
        {
            isInvincible = false;
            invincibleTimer = time;
        }

        public void Kill()
        {
            StartCoroutine(GetDead());
        }

        private IEnumerator GetDead()
        {
            if (!isDead)
            {
                curHP = 0.0f;
                isDead = true;

                if (animator)
                    if (animTriggers.ContainsKey(deadTrigger))
                        animator.SetTrigger(animTriggers[deadTrigger]);

                yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

                onDead.Invoke(new HealthEventArgs());
            }
        }
    }
}