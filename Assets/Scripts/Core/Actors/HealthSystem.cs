using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public abstract class HealthSystem : MonoBehaviour
    {
        [SerializeField] private ActorController controller;

        [Space(10.0f)]
        [SerializeField] private float _maxHP;
        [SerializeField] private float _curHP;

        public float maxHP 
        {
            get => _maxHP; 
            protected set => _maxHP = value; 
        }

        public float curHP 
        { 
            get => _curHP; 
            protected set => _curHP = value; 
        }

        public float healthAmount 
        { 
            get => curHP / maxHP; 
        }

        [Space(10.0f)]
        [SerializeField] private bool _isDead;

        [Space(10.0f)]
        [SerializeField] private bool _isInvincible;
        [SerializeField] private float _invincibleTimer;

        public bool isDead
        {
            get => _isDead;
            protected set => _isDead = value;
        }

        public bool isInvincible
        {
            get => _isInvincible;
            protected set => _isInvincible = value;
        }

        public float invincibleTimer
        {
            get => _invincibleTimer;
            protected set => _invincibleTimer = value;
        }


        protected Dictionary<string, ActorAnimationArgs> animTriggers;

        [Space(10.0f)]
        [SerializeField] protected Animator animator;

        [Space(5.0f)]
        [SerializeField] protected string healthTrigger;
        [SerializeField] protected string deadTrigger;
        [SerializeField] protected string idleTrigger;
        [SerializeField] protected string hurtTrigger;

        [Space(10.0f)]
        [SerializeField] protected HealthEvent onHurt;
        [SerializeField] protected HealthEvent onDead;

        protected virtual void Reset()
        {
            //controller = GetComponent<ActorController>();
            //
            //maxHP = curHP = controller.parameter.maxHP;

            animator = GetComponentInChildren<Animator>();

            healthTrigger = "Health";
            deadTrigger = "Dead";
            idleTrigger = "Idle";
            hurtTrigger = "Hurt";

            onHurt = new HealthEvent();
            onDead = new HealthEvent();
        }

        protected virtual void Awake()
        {
            animTriggers = new Dictionary<string, ActorAnimationArgs>();

            animTriggers.Add(healthTrigger, new ActorAnimationArgs { argName = healthTrigger, argHash = Animator.StringToHash(healthTrigger) });
            animTriggers.Add(idleTrigger, new ActorAnimationArgs { argName = idleTrigger, argHash = Animator.StringToHash(idleTrigger) });
            animTriggers.Add(hurtTrigger, new ActorAnimationArgs { argName = hurtTrigger, argHash = Animator.StringToHash(hurtTrigger) });
            animTriggers.Add(deadTrigger, new ActorAnimationArgs { argName = deadTrigger, argHash = Animator.StringToHash(deadTrigger) });

            onHurt = onHurt ?? new HealthEvent();
            onDead = onDead ?? new HealthEvent(); 
        }

        protected virtual void Update()
        {
            if (isInvincible)
            {
                if ((invincibleTimer -= Time.deltaTime) <= 0.0f)
                {
                    isInvincible = false;
                    invincibleTimer = 0.0f;
                }
            }
        }

        public virtual void TakeDamage(float damage)
        {
            if (!isInvincible && !_isDead)
            {
                curHP -= damage;

                if (curHP > 0.0f)
                {
                    if (animator)
                    {
                        if (animTriggers.ContainsKey(hurtTrigger)) animator.SetTrigger(animTriggers[hurtTrigger]);
                    }

                    onHurt.Invoke(new HealthEventArgs());
                }
                else
                {
                    curHP = 0.0f;

                    if (animator)
                    {
                        if (animTriggers.ContainsKey(deadTrigger)) animator.SetTrigger(animTriggers[deadTrigger]);
                    }

                    onDead.Invoke(new HealthEventArgs());
                }
            }
        }

        public virtual void ActiveInvincible(float time)
        {
            isInvincible = true;
            invincibleTimer = time;
        }
    }
}