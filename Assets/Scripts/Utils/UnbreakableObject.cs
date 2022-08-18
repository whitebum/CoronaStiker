using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Utils
{
    public class UnbreakableObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}