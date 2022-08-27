using CoronaStriker.Core.Effects;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class PlayerHealth : HealthSystem
    {
        [Space(10.0f)]
        [SerializeField] private bool isHurt;
        [SerializeField] private float hurtInvincibleTimer;

        [Space(10.0f)]
        [SerializeField] private bool isShield;

        [Space(10.0f)]
        [SerializeField] private BaseEffect healEffect;
        [SerializeField] private BaseEffect shieldEffect;
        [SerializeField] private BaseEffect invincibleEffect;
        [SerializeField] private FlashEffect flashEffect;
 
        [Space(10.0f)]
        [SerializeField] private int healthLayerIdx;
        [SerializeField] private int stateLayerIdx;

        [Space(10.0f)]
        [SerializeField] private HealthEvent onHeal;

        protected override void Reset()
        {
            base.Reset();
        }

        protected override void Awake()
        {
            base.Awake();

            onHeal.AddListener((arg) => { UpdateHealth(); });
            onHeal.AddListener((arg) => { if (healEffect) healEffect.OnEffectOnce(); });

            onHurt.AddListener((arg) => { UpdateHealth(); });
            onHurt.AddListener((arg) => { });

            onDead.AddListener((arg) => { gameObject.SetActive(false); });
        }

        private void Start()
        {
            UpdateHealth();
        }

        protected override void Update()
        {
            if (isInvincible)
            {
                if ((invincibleTimer -= Time.deltaTime) <= 0.0f)
                {
                    isInvincible = false;
                    invincibleTimer = 0.0f;

                    invincibleEffect.OffEffect();
                }
            }

            if (isHurt)
            {
                if ((hurtInvincibleTimer -= Time.deltaTime) <= 0.0f)
                {
                    isHurt = false;
                    hurtInvincibleTimer = 0.0f;

                    if (animTriggers.ContainsKey(idleTrigger))
                        animator?.ResetTrigger(animTriggers[idleTrigger]);
                }
            }

            if (Input.GetKeyDown(KeyCode.KeypadPlus))
                TakeHealth(1.0f);

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
                TakeDamage(1.0f);
        }

        public void UpdateHealth()
        {
            if (animTriggers.ContainsKey(healthTrigger))
                animator?.SetInteger(animTriggers[healthTrigger], (int)curHP);
        }

        public void TakeHealth(float health)
        {
            if (!isDead)
            {
                if (curHP >= maxHP)
                    return;

                var calHealth = curHP + health;

                if (calHealth >= maxHP)
                    curHP = maxHP;
                else
                    curHP = calHealth;

                onHeal.Invoke(new HealthEventArgs());
            }
        }

        public override void TakeDamage(float damage)
        {
            if (isShield)
            {
                isShield = false;
                shieldEffect.OffEffect();
            }
            else if (!isHurt && !isInvincible && !isDead)
            {
                var calHealth = curHP - damage;

                // Dead
                if (calHealth <= 0.0f)
                {
                    Kill();
                }
                else
                {
                    curHP = calHealth;

                    SetHurtInvincible(2.0f);
                    onHurt.Invoke(new HealthEventArgs());
                }
            }
        }

        public void GetInvincible(float time)
        {
            // if player hurted
            if (isHurt)
            {
                isHurt = false;
                hurtInvincibleTimer = 0.0f;

                if (animTriggers.ContainsKey(idleTrigger))
                    animator?.SetTrigger(animTriggers[idleTrigger]);
            }

            isInvincible = false;
            invincibleTimer = time;

            invincibleEffect.OnEffect();
        }

        public void SetHurtInvincible(float time = 10.0f)
        {
            if (!isHurt)
            {
                isHurt = true;
                hurtInvincibleTimer = time;

                //if (animTriggers.ContainsKey(hurtTrigger))
                //    animator?.SetTrigger(animTriggers[hurtTrigger]);

                animator?.SetTrigger("Hurt");
            }
        }

        public void GetShield()
        {
            if (!isShield)
            {
                isShield = true;
                shieldEffect.OnEffect();
            }
        }

        public void Kill()
        {
            StartCoroutine(GetDead());
        }

        private IEnumerator GetDead()
        {
            if (!isDead)
            {
                curHP = 0.0f;
                isDead = true;

                animator.SetTrigger(animTriggers[deadTrigger]);

                yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

                onDead.Invoke(new HealthEventArgs());
            }
        }
    }
}