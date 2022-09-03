using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.Core.Utils;
using CoronaStriker.Core.Effects;

namespace CoronaStriker.Core.Actors
{
    public class VirusHealth : HealthSystem
    {
        [SerializeField] private int maxHP;
        [SerializeField] private int curHP;

        [Space(10.0f)]
        [SerializeField] private bool isDead;

        [Space(10.0f)]
        [SerializeField] private bool isInvincible;
        [SerializeField] private float invincibleTimer;

        [Space(10.0f)]
        [SerializeField] private ActorGraphics graphics;

        [Space(5.0f)]
        [SerializeField] private int healthLayerId;
        [SerializeField] private int stateLayerId;

        [Space(5.0f)]
        [SerializeField] private string hurtParam;
        [SerializeField] private string deadParam;

        [Space(10.0f)]
        public HealthEvent onHurt;
        public HealthEvent onDead;

        private void Reset()
        {
            maxHP = curHP = 5;

            graphics = GetComponent<ActorGraphics>();

            hurtParam = "Hurt";
            deadParam = "Dead";

            onHurt = new HealthEvent();
            onDead = new HealthEvent();
        }

        private void Awake()
        {
            maxHP = curHP = 5;

            isDead = false;

            isInvincible = false;
            invincibleTimer = 0.0f;

            healthLayerId = graphics?.GetLayerIndex("Health Layer") ?? -1;
            stateLayerId = graphics?.GetLayerIndex("State Layer") ?? -1;

            graphics?.AddParam(hurtParam);
            graphics?.AddParam(deadParam);

            onHurt = onHurt ?? new HealthEvent();
            onDead = onDead ?? new HealthEvent();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                GetDamage(1);
        }

        public void GetDamage(int damage)
        {
            if (!isDead)
            {
                curHP -= damage;

                if (curHP <= 0)
                {
                    isDead = true;
                    curHP = 0;

                    graphics?.SetTrigger(deadParam);

                    gameObject.transform.localScale *= 2.0f;

                    StartCoroutine(DeadCoroutine());
                }
                else
                {
                    graphics?.SetBool(hurtParam, true);
                }
            }
        }

        private IEnumerator DeadCoroutine()
        {
            yield return new WaitForSecondsRealtime(graphics?.GetCurrentAnimationLength(stateLayerId) ?? 0.0f);

            gameObject.SetActive(true);

            onDead?.Invoke(curHP);
        }
    }
}