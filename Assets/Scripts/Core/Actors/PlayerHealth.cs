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

        [Space(5.0f)]
        [SerializeField] private bool isDead;

        [Space(5.0f)]
        [SerializeField] private bool isHurt;
        [SerializeField] private float hurtInvincibleTimer;

        [Space(5.0f)]
        [SerializeField] private bool isInvincible;
        [SerializeField] private float invincibleTimer;

        [Space(5.0f)]
        [SerializeField] private bool isShield;

        [Space(5.0f)]
        [SerializeField] private HealthEffect healEffect;
        [SerializeField] private ShieldEffect shieldEffect;
        [SerializeField] private InvincibleEffect invincibleEffect;

        [Space(5.0f)]
        [SerializeField] private ActorGraphics graphics;
        //[SerializeField] private Animator animator;

        [Space(5.0f)]
        [SerializeField] private int healthLayerId;
        [SerializeField] private int stateLayerId;

        [Space(5.0f)]
        [SerializeField] private string healthTrigger;
        [SerializeField] private string hurtTrigger;
        [SerializeField] private string deadTrigger;

        [Space(5.0f)]
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

            healEffect = transform.GetComponentInChildren<HealthEffect>();
            shieldEffect = transform.GetComponentInChildren<ShieldEffect>();
            invincibleEffect = transform.GetComponentInChildren<InvincibleEffect>();

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

            healthLayerId = graphics.GetLayerIndex("Health Layer");
            stateLayerId = graphics.GetLayerIndex("State Layer");

            graphics.AddParam(healthTrigger);
            graphics.AddParam(hurtTrigger);
            graphics.AddParam(deadTrigger);

            onHeal = onHeal ?? new UnityEvent<int>();
            onHurt = onHurt ?? new UnityEvent<int>();
            onDead = onDead ?? new UnityEvent<int>();
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

                    GetHurtInvincible(2.0f);
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

            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.KeypadPlus))
                    GetHealth(1);

                if (Input.GetKeyDown(KeyCode.KeypadMinus))
                    GetDamage(1);

                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    GetShield();
            }
        }

        public void GetHealth(int health = 1)
        {
            if (curHP < maxHP)
            {
                curHP += health;

                if (curHP > maxHP)
                    curHP = maxHP;

                graphics?.SetInteger(healthTrigger, curHP);
                healEffect?.OnEffect();

                onHeal?.Invoke(curHP);
            }
        }

        public void GetDamage(int damage = 1)
        {
            if (!isHurt && !isInvincible && !isDead)
            {
                if (isShield)
                {
                    isShield = false;
                    shieldEffect?.OffEffect();

                    GetHurtInvincible(2.0f);
                }
                else
                {
                    curHP -= damage;

                    if (curHP <= 0)
                    {
                        curHP = 0;
                        isDead = true;

                        graphics?.SetTrigger(deadTrigger);

                        void Temp() => gameObject.SetActive(false);

                        Invoke(nameof(Temp), graphics.GetCurrentAnimationLength(stateLayerId));

                        onDead?.Invoke(curHP);
                    }
                    else
                    {
                        onHurt?.Invoke(curHP);
                        graphics?.SetInteger(healthTrigger, curHP);

                        GetHurtInvincible(2.0f);
                    }
                }
            }
        }

        public void GetShield()
        {
            isShield = true;
            shieldEffect?.OnEffect();
        }

        public void GetInvincible(float time)
        {
            isInvincible = true;
            invincibleTimer = time;

            invincibleEffect?.OnEffect();
        }
        
        public void GetHurtInvincible(float time)
        {
            isHurt = true;
            hurtInvincibleTimer = time;

            graphics?.SetBool(hurtTrigger, true);
        }
    }   
}