using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    public abstract class Audio : ScriptableObject
    {
        [SerializeField] protected AudioClip _original;
        [SerializeField] protected AudioSource _speaker;

        public AudioClip original { get => _original; }
        public AudioSource speaker { get => _speaker; }
    }
}