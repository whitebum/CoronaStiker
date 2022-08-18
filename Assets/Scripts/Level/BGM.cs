using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    [CreateAssetMenu(fileName = "New BGM", menuName = "Create New Audio/BGM", order = int.MaxValue)]
    public sealed class BGM : Audio
    {
        [SerializeField] private bool _isLoop;
        [SerializeField] private float _loopStart;
        [SerializeField] private float _loopEnd;

        public bool isLoop { get => _isLoop; }
        public float loopStart { get => _loopStart; }
        public float loopEnd { get => _loopEnd; }
    }
}