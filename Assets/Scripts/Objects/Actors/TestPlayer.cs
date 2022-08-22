using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Objects.Actors
{
    public class TestPlayer : MonoBehaviour
    {
        [SerializeField] private Dictionary<string, int> triggers;

        [SerializeField] private string hpIntegerName = "Current HP";
        [SerializeField] private string deadTriggerName = "Dead";

        private void Awake()
        {
            triggers = new Dictionary<string, int>();

            triggers.Add(hpIntegerName, Animator.StringToHash(hpIntegerName));
            triggers.Add(deadTriggerName, Animator.StringToHash(deadTriggerName));
        }
    }
}