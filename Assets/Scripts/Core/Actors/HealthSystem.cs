using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public abstract class HealthSystem : MonoBehaviour
    {
        [Tooltip("������ �ִ� ü��")]
        public float maxHP;
        [Tooltip("������ ���� ü��")]
        public float curHP;

        [Space(5.0f)]
        [Tooltip("������ ��� ����")]
        [SerializeField] protected bool isDead;

        [Space(5.0f)]
        [Tooltip("������ ���� ����")]
        [SerializeField] protected bool isInvincible;
        [Tooltip("������ ���� �ð� Ÿ�̸�")]
        [SerializeField] protected float invincibleTimer;

        [Header("�ִϸ��̼� Ʈ����")]
        [Tooltip("������ �ִϸ�����")]
        [SerializeField] protected Animator animator;

        [Space(5.0f)]
        [SerializeField] protected ActorAnimationParam healthParam;
        [SerializeField] protected ActorAnimationParam hurtParam;
        [SerializeField] protected ActorAnimationParam deadParam;

        [Header("�̺�Ʈ")]
        [Tooltip("���Ͱ� ȸ������ ���� �̺�Ʈ")]
        public UnityEvent onHeal;
        [Tooltip("���Ͱ� ���ظ� �Ծ��� ���� �̺�Ʈ")]
        public UnityEvent onHurt;
        [Tooltip("���Ͱ� �׾��� ���� �̺�Ʈ")]
        public UnityEvent onDead;

        protected virtual void Reset()
        {
            maxHP = curHP = 1.0f;

            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();

            animator = GetComponentInChildren<Animator>();

            healthParam = new ActorAnimationParam { paramName = "Heal", paramHash = Animator.StringToHash("Heal") };
            hurtParam = new ActorAnimationParam { paramName = "Hurt", paramHash = Animator.StringToHash("Hurt") };
            deadParam = new ActorAnimationParam { paramName = "Dead", paramHash = Animator.StringToHash("Dead") };
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

            healthParam = healthParam ?? new ActorAnimationParam { paramName = "Heal", paramHash = Animator.StringToHash("Heal") };
            hurtParam = hurtParam ?? new ActorAnimationParam { paramName = "Hurt", paramHash = Animator.StringToHash("Hurt") };
            deadParam = deadParam ?? new ActorAnimationParam { paramName = "Dead", paramHash = Animator.StringToHash("Dead") };
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

                    animator?.SetTrigger(deadParam?.paramName);
                    onDead?.Invoke();
                }
                else
                {
                    curHP = temp;

                    animator?.SetTrigger(hurtParam?.paramName);
                    onHurt?.Invoke();
                }
            }
        }

        public void SetInvincible(float time)
        {
            invincibleTimer = time;
            isInvincible = true;
        }
    }
}