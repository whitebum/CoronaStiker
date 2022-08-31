using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class Bullet : MonoBehaviour
    {
        public UnityEvent onDisable;

        private void Reset()
        {
            onDisable = new UnityEvent();
        }

        private void Awake()
        {
            onDisable = onDisable ?? new UnityEvent();
        }

        public void Update()
        {
            transform.Translate(20.0f * Time.deltaTime * Vector3.up);
        }

        private void OnBecameInvisible()
        {
            Debug.Log("dd");
            onDisable.Invoke();
        }
    }
}