using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : class
    {
        private static T _instance = null;
        private static object _lock = new object();
        private static bool isInstanceDestroy = false;

        public static T GetInstance()
        {
            if (isInstanceDestroy)
            {
                return null;
            }

            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = FindObjectOfType(typeof(T)) as T;

                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GameObject($"{typeof(T)}").AddComponent(typeof(T)) as T;
                        }
                    }
                }
            }

            return _instance;
        }

        // �ν��Ͻ� ���� �Ŀ��� ȣ��Ǵ� ���� ���� ����.
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