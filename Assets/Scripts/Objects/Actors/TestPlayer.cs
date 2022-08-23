using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Objects.Actors
{
    public class TestPlayer : MonoBehaviour
    {
        [SerializeField] private Dictionary<string, int> triggers;

        [SerializeField] private HealthSystem health;

        [SerializeField] private string hpIntegerName = "Current HP";
        [SerializeField] private string deadTriggerName = "Dead";

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;

        private void Awake()
        { 
            triggers = new Dictionary<string, int>();

            triggers.Add(hpIntegerName, Animator.StringToHash(hpIntegerName));
            triggers.Add(deadTriggerName, Animator.StringToHash(deadTriggerName));

            UpdatePlayerSprite();
        }

        public void UpdatePlayerSprite()
        {
            animator.SetFloat("Current HP", health.curHP);
        }
    }
}