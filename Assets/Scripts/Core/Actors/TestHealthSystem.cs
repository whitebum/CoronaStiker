using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Core.Actors
{
    public class TestHealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHP;
        [SerializeField] private float curHP;

        [Space(5.0f)]
        [SerializeField] private Animator animator;
        [SerializeField] private List<ActorAnimationArgs> animationParams;

        [Space(5.0f)]
        public UnityEvent onHeal;
        public UnityEvent onHurt;
        public UnityEvent onDead;

        private void Reset()
        {
            animationParams = new List<ActorAnimationArgs>();

            animationParams.Add(new ActorAnimationArgs { argName = "Health", argHash = Animator.StringToHash("Health") });
            animationParams.Add(new ActorAnimationArgs { argName = "Damage", argHash = Animator.StringToHash("Damage") });
            animationParams.Add(new ActorAnimationArgs { argName = "Dead", argHash = Animator.StringToHash("Dead") });

            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();
        }

        private void Awake()
        {
            animationParams = animationParams ?? new List<ActorAnimationArgs>();

            onHeal = onHeal ?? new UnityEvent();
            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();
        }
    }
}