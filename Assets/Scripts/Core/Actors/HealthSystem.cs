using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public abstract class HealthSystem : MonoBehaviour
    {
        public float maxHP { get; protected set; }        
        public float curHP { get; protected set; }

        public bool isInvincible { get; protected set; }
        public float invincbleTimer { get; protected set; }

        public bool isDead { get; protected set; }

        [Space(5.0f)]
        [SerializeField] private UnityEvent onHeal;
        [SerializeField] private UnityEvent onHurt;
        [SerializeField] private UnityEvent onDead;

        protected virtual void Reset()
        {
            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();

            isDead = false;
        }

        protected virtual void Awake()
        {
            curHP = maxHP;

            isDead = false;

            onHeal = onHeal ?? new UnityEvent();
            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();
        }

        public virtual void TakeDamage(float damage)
        {
            if (isInvincible || isDead)
                return;

            var temp = curHP - damage;

            curHP = temp > maxHP ? maxHP : temp;

            cur
        }
    }
}