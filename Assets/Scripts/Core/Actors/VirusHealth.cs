using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.Core.Utils;
using CoronaStriker.Core.Effects;

namespace CoronaStriker.Core.Actors
{
    public class VirusHealth : HealthSystem
    {
        [SerializeField] private int maxHP;
        [SerializeField] private int curHP;

        [Space(10.0f)]
        [SerializeField] private bool isDead;

        [Space(10.0f)]
        [SerializeField] private bool isInvincible;
        [SerializeField] private float invincibleTimer;

        [Space(10.0f)]
        [SerializeField] private Animator animator;

        [Space(5.0f)]
        [SerializeField] private int healthLayerIdx;
        [SerializeField] private int stateLayerIdx;

        private Dictionary<string, AnimationArgs> animatorArgs;

        [Space(5.0f)]
        [SerializeField] private string hurtTrigger;
        [SerializeField] private string deadTrigger;

        [Space(10.0f)]
        //public HealthEvent onHeal;
        //public HealthEvent onHurt;
        //public HealthEvent onDead;
        public UnityEvent onHeal;
        public UnityEvent onHurt;
        public UnityEvent onDead;

        private void Reset()
        {
            maxHP = curHP = 5;

            animator = GetComponent<Animator>();

            hurtTrigger = "";
            deadTrigger = "";

            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();
        }

        private void Awake()
        {
            maxHP = curHP = 5;

            isDead = false;

            isInvincible = false;
            invincibleTimer = 0.0f;

            animatorArgs = new Dictionary<string, AnimationArgs>();

            healthLayerIdx = animator.GetLayerIndex("Health Layer");
            stateLayerIdx = animator.GetLayerIndex("State Layer");

            animatorArgs.Add(hurtTrigger, new AnimationArgs { argName = hurtTrigger, argHash = Animator.StringToHash(hurtTrigger) });
            animatorArgs.Add(deadTrigger, new AnimationArgs { argName = deadTrigger, argHash = Animator.StringToHash(deadTrigger) });

            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();

            onDead.AddListener(() => gameObject.SetActive(false));
        }

        public void GetDamage(int damage)
        {
            if (!isDead)
            {
                curHP -= damage;

                if (curHP <= 0)
                {
                    curHP = 0;

                    onDead.Invoke();
                }
                else
                {
                    if (animatorArgs?.ContainsKey(hurtTrigger) == true)
                    {
                        if (animator?.GetBool(animatorArgs[hurtTrigger]) == false)
                            animator?.SetBool(animatorArgs[hurtTrigger], true);
                    }
                }
            }
        }

        
    }
}