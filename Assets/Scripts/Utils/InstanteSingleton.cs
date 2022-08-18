using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Utils
{
    [RequireComponent(typeof(UnbreakableObject))]
    public abstract class InstanteSingleton<T> : MonoBehaviour where T : class
    {
        private static T instance { get; set; }

        public static T GetInstance
        {
            get => instance ?? null;
        }

        protected virtual void Awake()
        {
            if (instance != null)
                Destroy(gameObject);

            instance = TryGetComponent<T>(out var temp) ? temp : null;
        }
    }
}