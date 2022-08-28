using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.Core.Actors
{
    public abstract class HealthSystem : MonoBehaviour
    {
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

        protected Animator animator 
        { 
            get; private set; 
        }
        protected Dictionary<string, AnimationArgs> animTriggers
        {
            get;
            private set;
        }

        [Space(10.0f)]
        public HealthEvent onHurt;
        public HealthEvent onDead;

        protected virtual void Reset()
        {
            animator = GetComponentInChildren<Animator>();

            onHurt = new HealthEvent();
            onDead = new HealthEvent();
        }

        protected virtual void Awake()
        {
            animTriggers = new Dictionary<string, AnimationArgs>();

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
    }
}