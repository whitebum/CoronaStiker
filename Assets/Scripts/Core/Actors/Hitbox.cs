using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Hitbox : MonoBehaviour
    {
        [Tooltip("액터의 Colider")]
        [SerializeField] protected Collider2D colider;

        [Header("이벤트들")]
        public UnityEvent onTriggerEnter;
        public UnityEvent onTriggerStay;
        public UnityEvent onTriggerExit;

        private void Reset()
        {
            colider = GetComponent<Collider2D>();
            
            colider.isTrigger = true;

            onTriggerEnter = new UnityEvent();
            onTriggerStay = new UnityEvent();
            onTriggerExit = new UnityEvent();
        }

        private void Awake()
        {
            colider = colider ?? GetComponent<Collider2D>();

            onTriggerEnter = onTriggerEnter ?? new UnityEvent();
            onTriggerStay = onTriggerStay ?? new UnityEvent();
            onTriggerExit = onTriggerExit ?? new UnityEvent();
        }
    }
}