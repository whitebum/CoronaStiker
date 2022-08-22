using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Objects.Actors
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHP;
        [SerializeField] private float curHp;

        [SerializeField] private UnityEvent onHeal;
        [SerializeField] private UnityEvent onHurt;
        [SerializeField] private UnityEvent onDead;

        private void OnValidate()
        {
            curHp = maxHP;

            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();
        }

        private void Awake()
        {
            if (curHp != maxHP)
                curHp = maxHP;

            onHeal = onHeal ?? new UnityEvent();
            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();
        }
    }
}