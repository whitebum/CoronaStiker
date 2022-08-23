using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Objects.Actors
{
    public abstract class HealthSystem : MonoBehaviour
    {
        public int maxHP { get; protected set; }        
        public int curHP { get; protected set; }

        [Space(5.0f)]
        [SerializeField] private bool isDead;

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
    }
}