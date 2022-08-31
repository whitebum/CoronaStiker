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
        [SerializeField] private PlayerController controller;

        public int maxHP
        {
            get => controller.playerParam.maxHP;
        }

        public int curHP
        {
            get;
            private set;
        }

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
        [SerializeField] private ActorGraphics graphics;
        //[SerializeField] private Animator animator;

        [Space(5.0f)]
        [SerializeField] private int healthLayerIdx;
        [SerializeField] private int stateLayerIdx;

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
            curHP = maxHP;

            var temp = transform.Find("Effects");

            healEffect = transform.GetComponentInChildren<HealEffect>();
            shieldEffect = transform.GetComponentInChildren<ShieldEffect>();
            invincibleEffect = transform.GetComponentInChildren<InvincibleEffect>();
            boostEffect = transform.GetComponentInChildren<BoostEffect>();

            graphics = GetComponentInChildren<ActorGraphics>();
            //animator = GetComponent<Animator>();

            healthTrigger = "";
            hurtTrigger = "";
            deadTrigger = "";

            onHeal = new UnityEvent<int>();
            onHurt = new UnityEvent<int>();
            onDead = new UnityEvent<int>();
        }

        private void Awake()
        {
            curHP = maxHP;

            isDead = false;

            isInvincible = false;
            invincibleTimer = 0.0f;

            isHurt = false;
            hurtInvincibleTimer = 0.0f;

            healthLayerIdx = graphics.GetLayerIndex("Health Layer");
            stateLayerIdx = graphics.GetLayerIndex("State Layer");

            graphics.AddArg(healthTrigger);
            graphics.AddArg(hurtTrigger);
            graphics.AddArg(deadTrigger);

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

                    graphics?.SetBool(hurtTrigger, false);
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
            graphics?.SetInteger(healthTrigger, curHP);
        }

        public void GetHurt(float time)
        {
            isHurt = true;
            hurtInvincibleTimer = time;

            graphics?.SetTrigger(hurtTrigger);
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

                graphics?.SetTrigger(deadTrigger);

                onDead?.Invoke(curHP);
            }
        }
    }   
}