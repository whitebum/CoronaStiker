using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.Core.Actors
{
    public class VirusHealth : HealthSystem
    {
        [Space(10.0f)]
        [SerializeField] private int healthLayerIndex;
        [SerializeField] private int stateLayerIndex;

        [Space(5.0f)]
        [SerializeField] private string hurtTrigger;
        [SerializeField] private string deadTrigger;

        protected override void Reset()
        {
            base.Reset();

            hurtTrigger = "";
            deadTrigger = "";
        }

        protected override void Awake()
        {
            base.Awake();

            healthLayerIndex = animator.GetLayerIndex("Health Layer");
            healthLayerIndex = animator.GetLayerIndex("State Layer");

            animTriggers.Add(hurtTrigger, new AnimationArgs { argName = hurtTrigger, argHash = Animator.StringToHash(hurtTrigger) });
            animTriggers.Add(deadTrigger, new AnimationArgs { argName = deadTrigger, argHash = Animator.StringToHash(deadTrigger) });
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

                if (animTriggers.ContainsKey(deadTrigger)) animator?.SetTrigger(animTriggers[deadTrigger]);

                yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

                onDead.Invoke(new HealthEventArgs());
            }
        }
    }
}