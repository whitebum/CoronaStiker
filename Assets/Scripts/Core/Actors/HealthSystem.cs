using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public abstract class HealthSystem : MonoBehaviour
    {
        [Tooltip("액터의 최대 체력")]
        public float maxHP;
        [Tooltip("액터의 현재 체력")]
        public float curHP;

        [Space(5.0f)]
        [Tooltip("액터의 사망 여부")]
        [SerializeField] protected bool isDead;

        [Space(5.0f)]
        [Tooltip("액터의 무적 여부")]
        [SerializeField] protected bool isInvincible;
        [Tooltip("액터의 무적 시간 타이머")]
        [SerializeField] protected float invincibleTimer;

        [Header("애니메이션 트리거")]
        [Tooltip("액터의 애니메이터")]
        [SerializeField] protected Animator animator;

        [Space(5.0f)]
        [SerializeField] protected ActorAnimationArgs healthParam;
        [SerializeField] protected ActorAnimationArgs hurtParam;
        [SerializeField] protected ActorAnimationArgs deadParam;

        [Header("이벤트")]
        [Tooltip("액터가 회복했을 때의 이벤트")]
        public UnityEvent onHeal;
        [Tooltip("액터가 피해를 입었을 때의 이벤트")]
        public UnityEvent onHurt;
        [Tooltip("액터가 죽었을 때의 이벤트")]
        public UnityEvent onDead;

        protected virtual void Reset()
        {
            maxHP = curHP = 1.0f;

            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();

            animator = GetComponentInChildren<Animator>();

            healthParam = new ActorAnimationArgs { argName = "Heal", argHash = Animator.StringToHash("Heal") };
            hurtParam = new ActorAnimationArgs { argName = "Hurt", argHash = Animator.StringToHash("Hurt") };
            deadParam = new ActorAnimationArgs { argName = "Dead", argHash = Animator.StringToHash("Dead") };
        }

        protected virtual void OnValidate()
        {
            if (maxHP != curHP)
                maxHP = curHP;
        }

        protected virtual void Awake()
        {
            curHP = maxHP;

            isDead = false;

            isInvincible = false;
            invincibleTimer = 0.0f;

            animator = animator ?? GetComponentInChildren<Animator>();

            onHeal = onHeal ?? new UnityEvent();
            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();

            healthParam = healthParam ?? new ActorAnimationArgs { argName = "Heal", argHash = Animator.StringToHash("Heal") };
            hurtParam = hurtParam ?? new ActorAnimationArgs { argName = "Hurt", argHash = Animator.StringToHash("Hurt") };
            deadParam = deadParam ?? new ActorAnimationArgs { argName = "Dead", argHash = Animator.StringToHash("Dead") };
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
            if (!isInvincible || !isDead)
            {
                var temp = curHP - damage;

                if (curHP <= 0.0f)
                {
                    isDead = true;

                    curHP = 0.0f;

                    animator?.SetTrigger(deadParam?.argName);
                    onDead?.Invoke();
                }
                else
                {
                    curHP = temp;

                    animator?.SetTrigger(hurtParam?.argName);
                    onHurt?.Invoke();
                }
            }
        }

        public void SetInvincible(float time)
        {
            invincibleTimer = time;
            isInvincible = true;
        }

        public static implicit operator string(HealthSystem health)
        {
            return $"Max HP: {health.maxHP:0.0} Current HP: {health.curHP:0.0}";
        }

        public static implicit operator float(HealthSystem health)
        {
            return health.curHP;
        }
    }
}