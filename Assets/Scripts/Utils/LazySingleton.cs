using System;
using UnityEngine;

namespace CoronaStriker.Utils
{
    [RequireComponent(typeof(UnbreakableObject))]
    public abstract class LazySingleton<T> : MonoBehaviour where T : class
    {
        // Lazy는 인스턴스 호출 시에 인스턴스를 생성함.
        private static Lazy<T> _instance = new Lazy<T>(() =>
        {
            var instance = FindObjectOfType(typeof(T)) as T;

            if (instance == null)
            {
                instance = new GameObject($"{typeof(T)}").AddComponent(typeof(T)) as T;
            }

            return instance;
        });
        private static bool isInstanceDestroy = false;

        public static T GetInstance()
        {
            return !isInstanceDestroy ? _instance.Value : null;
        }

        // 인스턴스 삭제 후에도 호출되는 것을 막기 위함.
        protected virtual void OnApplicationQuit()
        {
            isInstanceDestroy = true;
        }

        protected virtual void OnDestroy()
        {
            isInstanceDestroy = true;
        }
    }
}
