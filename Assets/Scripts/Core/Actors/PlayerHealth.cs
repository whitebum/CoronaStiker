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
        [SerializeField] private BaseEffect healEffect;
        [SerializeField] private BaseEffect shieldEffect;
        [SerializeField] private BaseEffect invincibleEffect;
        [SerializeField] private BaseEffect boostEffect;

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
        public UnityEvent onHeal;
        public UnityEvent onHurt;
        public UnityEvent onDead;

        private void Reset()
        {
            maxHP = curHP = 5;

            var temp = transform.Find("Effects");

            healEffect = temp.transform.Find("Heal").GetComponent<BaseEffect>();
            shieldEffect = temp.transform.Find("Shield").GetComponent<BaseEffect>();
            invincibleEffect = temp.transform.Find("Invincible").GetComponent<BaseEffect>();
            boostEffect = temp.transform.Find("Boost").GetComponent<BaseEffect>();

            animator = GetComponent<Animator>();

            healthTrigger = "";
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

            isHurt = false;
            hurtInvincibleTimer = 0.0f;

            animatorArgs = new Dictionary<string, AnimationArgs>();

            healthLayerIdx = animator.GetLayerIndex("Health Layer");
            stateLayerIdx = animator.GetLayerIndex("State Layer");

            animatorArgs.Add(healthTrigger, new AnimationArgs { argName = healthTrigger, argHash = Animator.StringToHash(healthTrigger) });
            animatorArgs.Add(hurtTrigger, new AnimationArgs { argName = hurtTrigger, argHash = Animator.StringToHash(hurtTrigger) });
            animatorArgs.Add(deadTrigger, new AnimationArgs { argName = deadTrigger, argHash = Animator.StringToHash(deadTrigger) });

            onHeal = onHeal ?? new UnityEvent();
            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();

            onHeal.AddListener(() => UpdateSprite());
            onHeal.AddListener(() => healEffect?.OnEffectOnce());

            onHurt.AddListener(() => UpdateSprite());
            onHurt.AddListener(() => GetHurt(2.0f));

            onDead.AddListener(() => gameObject.SetActive(false));
        }

        private void Update()
        {
            if (isInvincible)
            {
                if ((invincibleTimer -= Time.deltaTime) <= 0.0f)
                {
                    isInvincible = false;
                    invincibleTimer = 0.0f;
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

                onHeal.Invoke();
            }
        }

        public void GetDamage(int damage)
        {
            if (!isHurt && !isInvincible && !isDead)
            {
                curHP -= damage;

                if (curHP <= 0)
                {
                    curHP = 0;

                    GetDeath();
                }
                else
                {
                    GetHurt(2.0f);
                    onHurt.Invoke();
                }
            }
        }

        public void UpdateSprite()
        {
            if (animatorArgs?.ContainsKey(healthTrigger) == true)
                animator?.SetInteger(animatorArgs[healthTrigger], curHP);
        }

        public void GetHurt(float time = 2.0f)
        {
            isHurt = true;
            hurtInvincibleTimer = time;

            if (animatorArgs?.ContainsKey(hurtTrigger) == true)
                animator?.SetBool(animatorArgs[hurtTrigger], true);
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
                isDead = true;

                if (animatorArgs?.ContainsKey(deadTrigger) == true)
                    animator?.SetTrigger(animatorArgs[deadTrigger]);

                Invoke(nameof(onDead.Invoke), animator.GetCurrentAnimatorStateInfo(1).length);
            }
        }
    }   
}