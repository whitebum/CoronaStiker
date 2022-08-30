using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.Core.Utils;
using CoronaStriker.Core.Effects;

namespace CoronaStriker.Core.Actors
{
    public class PlayerHealth : HealthSystem
    {
        [SerializeField] private int maxHP;
        [SerializeField] private int curHP;

        [Space(10.0f)]
        [SerializeField] private bool isDead;

        [Space(10.0f)]
        [SerializeField] private bool isHurt;
        [SerializeField] private float hurtInvincibleTimer;

        [Space(10.0f)]
        [SerializeField] private bool isInvincible;
        [SerializeField] private float invincibleTimer;

        [Space(10.0f)]
        [SerializeField] private bool isShield;

        [Space(10.0f)]
        [SerializeField] private HealEffect healEffect;
        [SerializeField] private ShieldEffect shieldEffect;
        [SerializeField] private InvincibleEffect invincibleEffect;
        [SerializeField] private BoostEffect boostEffect;

        [Space(10.0f)]
        [SerializeField] private Animator animator;

        [Space(5.0f)]
        [SerializeField] private int healthLayerIdx;
        [SerializeField] private int stateLayerIdx;

        private Dictionary<string, AnimationArgs> animatorArgs;

        [Space(5.0f)]
        [SerializeField] private string healthTrigger;
        [SerializeField] private string hurtTrigger;
        [SerializeField] private string deadTrigger;

        [Space(10.0f)]
        //public HealthEvent onHeal;
        //public HealthEvent onHurt;
        //public HealthEvent onDead;
        public UnityEvent<int> onHeal;
        public UnityEvent<int> onHurt;
        public UnityEvent<int> onDead;

        private void Reset()
        {
            maxHP = curHP = 5;

            var temp = transform.Find("Effects");

            healEffect = transform.GetComponentInChildren<HealEffect>();
            shieldEffect = transform.GetComponentInChildren<ShieldEffect>();
            invincibleEffect = transform.GetComponentInChildren<InvincibleEffect>();
            boostEffect = transform.GetComponentInChildren<BoostEffect>();

            animator = GetComponent<Animator>();

            healthTrigger = "";
            hurtTrigger = "";
            deadTrigger = "";

            onHeal = new UnityEvent<int>();
            onHurt = new UnityEvent<int>();
            onDead = new UnityEvent<int>();
        }

        private void Awake()
        {
            maxHP = curHP = 5;

            isDead = false;

            isInvincible = false;
            invincibleTimer = 0.0f;

            isHurt = false;
            hurtInvincibleTimer = 0.0f;

            animatorArgs = new Dictionary<string, AnimationArgs>();

            healthLayerIdx = animator.GetLayerIndex("Health Layer");
            stateLayerIdx = animator.GetLayerIndex("State Layer");

            animatorArgs.Add(healthTrigger, new AnimationArgs { argName = healthTrigger, argHash = Animator.StringToHash(healthTrigger) });
            animatorArgs.Add(hurtTrigger, new AnimationArgs { argName = hurtTrigger, argHash = Animator.StringToHash(hurtTrigger) });
            animatorArgs.Add(deadTrigger, new AnimationArgs { argName = deadTrigger, argHash = Animator.StringToHash(deadTrigger) });

            onHeal = onHeal ?? new UnityEvent<int>();
            onHurt = onHurt ?? new UnityEvent<int>();
            onDead = onDead ?? new UnityEvent<int>();

            onHeal.AddListener((arg) => UpdateSprite());
            onHeal.AddListener((arg) => healEffect?.OnEffectOnce());

            onHurt.AddListener((arg) => UpdateSprite());
            onHurt.AddListener((arg) => GetHurt(2.0f));

        }

        private void Update()
        {
            if (isInvincible)
            {
                if ((invincibleTimer -= Time.deltaTime) <= 0.0f)
                {
                    isInvincible = false;
                    invincibleTimer = 0.0f;

                    invincibleEffect?.OffEffect();
                }
            }

            if (isHurt)
            {
                if ((hurtInvincibleTimer -= Time.deltaTime) <= 0.0f)
                {
                    isHurt = false;
                    hurtInvincibleTimer = 0.0f;

                    if (animatorArgs?.ContainsKey(hurtTrigger) == true)
                        animator?.SetBool(animatorArgs[hurtTrigger], false);
                }
            }
#if UNITY_EDITOR

            if (Input.GetKeyDown(KeyCode.KeypadPlus))
                GetHealth(1);

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
                GetDamage(1);

            if (Input.GetKeyDown(KeyCode.Return))
                GetInvincible(10.0f);
#endif
        }

        public void GetHealth(int health)
        {
            if (curHP < maxHP)
            {
                curHP += health;

                if (curHP > maxHP)
                    curHP = maxHP;

                onHeal?.Invoke(curHP);
            }
        }

        public void GetDamage(int damage)
        {
            if (!isHurt && !isInvincible && !isDead)
            {
                curHP -= damage;

                if (curHP <= 0)
                {
                    GetDeath();
                }
                else
                {
                    onHurt?.Invoke(curHP);
                }
            }
        }

        public void UpdateSprite()
        {
            if (animatorArgs?.ContainsKey(healthTrigger) == true)
                animator?.SetInteger(animatorArgs[healthTrigger], curHP);
        }

        public void GetHurt(float time)
        {
            isHurt = true;
            hurtInvincibleTimer = time;

            if (animatorArgs?.ContainsKey(hurtTrigger) == true)
                animator?.SetTrigger(animatorArgs[hurtTrigger]);

        }

        public void GetInvincible(float time)
        {
            isInvincible = true;
            invincibleTimer = time;

            invincibleEffect?.OnEffect();
        }

        public void GetDeath()
        {
            if (!isDead)
            {
                curHP = 0;
                isDead = true;

                if (animatorArgs?.ContainsKey(deadTrigger) == true)
                    animator?.SetTrigger(animatorArgs[deadTrigger]);

                onDead?.Invoke(curHP);
            }
        }
    }   
}