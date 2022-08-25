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
        [Tooltip("액터와 객체가 겹쳤을 때의 이벤트")]
        public UnityEvent onTriggerEnter;
        [Tooltip("액터와 객체가 겹친 상태가 유지될 때의 이벤트")]
        public UnityEvent onTriggerStay;
        [Tooltip("액터와 객체가 겹친 상태에서 탈출했을 때의 이벤트")]
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