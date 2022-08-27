using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class EnemyHealth : HealthSystem
    {
        [SerializeField] private float maxHP;
        [SerializeField] private float curHP;

        public float MaxHP => maxHP;
        public float CurHP => curHP;
        public float healthAmount => curHP / maxHP;

        [Space(10.0f)]
        [SerializeField] private bool isDead;

        [Space(10.0f)]
        [SerializeField] private bool isInvincible;
        [SerializeField] private float invincibleTimer;

        private Dictionary<string, ActorAnimationArgs> animParams;

        [Space(10.0f)]
        [SerializeField] private Animator animator;

        [Space(5.0f)]
        [SerializeField] private int healthLayerIdx;
        [SerializeField] private int stateLayerIdx;

        [Space(5.0f)]
        [SerializeField] private string healthParam;
        [SerializeField] private string deadParam;
        [SerializeField] private string idleParam;
        [SerializeField] private string hurtParam;

        [Space(10.0f)]
        [SerializeField] private UnityEvent onHurt;
        [SerializeField] private UnityEvent onDead;

        private void Reset()
        {
            maxHP = curHP = 1.0f;

            animator = GetComponentInChildren<Animator>();

            healthLayerIdx = animator.GetLayerIndex("Health Layer");
            stateLayerIdx = animator.GetLayerIndex("State Layer");

            healthParam = "";
            deadParam = "";
            idleParam = "";
            hurtParam = "";

            onHurt = new UnityEvent();
            onDead = new UnityEvent();
        }

        private void Awake()
        {
            animator = animator ?? GetComponentInChildren<Animator>();

            animParams = new Dictionary<string, ActorAnimationArgs>();

            animParams.Add(healthParam, new ActorAnimationArgs { argName = healthParam, argHash = Animator.StringToHash(healthParam) });
            animParams.Add(deadParam, new ActorAnimationArgs { argName = deadParam, argHash = Animator.StringToHash(deadParam) });
            animParams.Add(idleParam, new ActorAnimationArgs { argName = idleParam, argHash = Animator.StringToHash(idleParam) });
            animParams.Add(hurtParam, new ActorAnimationArgs { argName = hurtParam, argHash = Animator.StringToHash(hurtParam) });

            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();
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

            if (Input.GetKeyDown(KeyCode.DownArrow))
                TakeDamage(1.0f);
        }

        public void TakeDamage(float damage)
        {
            if (!isDead && !isInvincible)
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

                    onHurt.Invoke();
                }
            }
        }

        public void GetInvincible(float time = 6.0f)
        {
            isInvincible = false;
            invincibleTimer = time;
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

                yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

                onDead.Invoke();
            }
        }
    }
}