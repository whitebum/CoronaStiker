using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    [CreateAssetMenu(fileName = "New SFX", menuName = "Audio/SFX", order = int.MaxValue)]
    public sealed class SFX : Audio
    {
        [SerializeField] private bool _isSpecial;

        public bool isSpecial { get => _isSpecial; }
    }
}
