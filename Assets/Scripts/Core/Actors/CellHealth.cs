using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class CellHealth : HealthSystem
    {
        [SerializeField] private float maxHP;
        [SerializeField] private float curHP;

        [Space(10.0f)]
        [SerializeField] private bool isDead;

        [Space(10.0f)]
        [SerializeField] private Animator animator;

        [Space(10.0f)]
        [SerializeField] private UnityEvent onDead;

        private void Reset()
        {
            maxHP = curHP = 1.0f;

            animator = GetComponentInChildren<Animator>();

            onDead = new UnityEvent();
        }

        private void Awake()
        {
            animator = animator ?? GetComponentInChildren<Animator>();

            onDead = onDead ?? new UnityEvent();
        }

        public void TakeDamage(float damage)
        {
            if (!isDead)
            {
                if (damage <= 0.0f)
                {
                    Kill();
                }
            }
        }

        public void Kill()
        {
            if (!isDead)
            {
                curHP = 0.0f;
                isDead = true;

                onDead.Invoke();
            }
        }
    }
}