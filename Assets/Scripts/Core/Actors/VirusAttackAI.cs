using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public abstract class VirusAttackAI : MonoBehaviour
    {
        [SerializeField] private Bullet useBullet;

        [Space(10.0f)]
        [SerializeField] private bool isCanAttak;
        
        [Space(5.0f)]
        [SerializeField] private float attackIntervalTime;
        [SerializeField] private float attackTimer;

        [SerializeField] protected BulletFactory factory;
        
        protected virtual void Reset()
        {
            factory = GetComponentInChildren<BulletFactory>();
        }

        protected virtual void Awake()
        {
            factory.Init(useBullet, 30);
        }

        private void Update()
        {
            if (isCanAttak)
            {
                var deltaTime = Time.deltaTime;

                if ((attackTimer -= deltaTime) <= 0.0f)
                {
                    Attack(deltaTime);
                    attackTimer = attackIntervalTime;
                }
            }
        }

        protected abstract void Attack(float deltaTime);
    }
}
