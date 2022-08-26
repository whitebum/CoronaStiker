using CoronaStriker.Core.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float maxHP;
        [SerializeField] private float curHP;

        public float MaxHP => maxHP;
        public float CurHP => curHP;
        public float healthAmount => curHP / maxHP;

        [Space(10.0f)]
        [SerializeField] private bool isDead;

        [Space(10.0f)]
        [SerializeField] private bool isHurt;
        [SerializeField] private float hurtInvincibleTimer;

        [Space(10.0f)]
        [SerializeField] private bool isShield;

        [Space(10.0f)]
        [SerializeField] private bool isInvincible;
        [SerializeField] private float invincibleTimer;

        [Space(10.0f)]
        [SerializeField] private BaseEffect healEffect;
        [SerializeField] private BaseEffect shieldEffect;
        [SerializeField] private BaseEffect invincibleEffect;

        private Dictionary<string, ActorAnimationArgs> animParams;

        [Space(10.0f)]
        [SerializeField] private Animator animator;
        [SerializeField] private int healthLayerIdx;
        [SerializeField] private int stateLayerIdx;

        [Space(5.0f)]
        [SerializeField] private string healthParam;
        [SerializeField] private string deadParam;
        [SerializeField] private string idleParam;
        [SerializeField] private string hurtParam;

        [Space(10.0f)]
        [SerializeField] private UnityEvent onHeal;
        [SerializeField] private UnityEvent onHurt;
        [SerializeField] private UnityEvent onDead;

        private void Reset()
        {
            maxHP = curHP = 5.0f;

            healthParam = "";
            deadParam = "";
            idleParam = "";
            hurtParam = "";

            animator = GetComponentInChildren<Animator>();
        }

        private void Awake()
        {
            animator = animator ?? GetComponentInChildren<Animator>();

            animParams = new Dictionary<string, ActorAnimationArgs>();

            animParams.Add(healthParam, new ActorAnimationArgs { argName = healthParam, argHash = Animator.StringToHash(healthParam) });
            animParams.Add(deadParam, new ActorAnimationArgs { argName = deadParam, argHash = Animator.StringToHash(deadParam) });
            animParams.Add(idleParam, new ActorAnimationArgs { argName = idleParam, argHash = Animator.StringToHash(idleParam) });
            animParams.Add(hurtParam, new ActorAnimationArgs { argName = hurtParam, argHash = Animator.StringToHash(hurtParam) });
        }

        private void Start()
        {
            UpdateHealth();
        }

        private void Update()
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

                    animator.SetTrigger(animParams[idleParam]);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
                TakeHealth(1.0f);

            if (Input.GetKeyDown(KeyCode.DownArrow))
                TakeDamage(1.0f);
        }

        private void UpdateHealth()
        {
            animator.SetInteger(animParams[healthParam], (int)curHP);
        }

        public void TakeHealth(float health)
        {
            if (curHP >= maxHP)
                return;

            var calHealth = curHP + health;

            if (calHealth >= maxHP)
                curHP = maxHP;
            else
                curHP = calHealth;

            onHeal.Invoke();
        }

        public void TakeDamage(float damage)
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

                    GetHurtInvincible(4.0f);
                    onHurt.Invoke();
                }
            }
        }

        public void GetInvincible(float time = 6.0f)
        {
            // if player hurted
            if (isHurt)
            {
                isHurt = false;
                hurtInvincibleTimer = 0.0f;
                
                animator.SetTrigger(animParams[idleParam]);
            }

            isInvincible = false;
            invincibleTimer = time;

            invincibleEffect.OnEffect();
        }

        public void GetHurtInvincible(float time = 10.0f)
        {
            if (!isHurt)
            {
                isHurt = true;
                hurtInvincibleTimer = time;

                animator.SetTrigger(animParams[hurtParam]);
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

                animator.SetTrigger(animParams[deadParam]);

                yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(stateLayerIdx).length);

                onDead.Invoke();
            }
        }
    }
}