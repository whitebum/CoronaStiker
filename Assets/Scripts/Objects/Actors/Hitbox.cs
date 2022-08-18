using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Actors
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Hitbox : MonoBehaviour
    {
        [Header("Member Properties Partition")]
        [SerializeField] protected Collider2D col;

        [Header("Events Partition")]
        [SerializeField] private UnityEvent onTriggerEnter;
        [SerializeField] private UnityEvent onTriggerStay;
        [SerializeField] private UnityEvent onTriggerExit;

        private void Reset()
        {
            TryGetComponent(out col);

            onTriggerEnter = new UnityEvent();
            onTriggerStay = new UnityEvent();
            onTriggerExit = new UnityEvent();
        }

        

        private void Awake()
        {
            col = col ?? GetComponent<Collider2D>();

            onTriggerEnter = onTriggerEnter ?? new UnityEvent();
            onTriggerStay = onTriggerStay ?? new UnityEvent();
            onTriggerExit = onTriggerExit ?? new UnityEvent();
        }
    }
}