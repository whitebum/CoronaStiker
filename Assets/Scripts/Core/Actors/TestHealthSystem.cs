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
        [SerializeField] private List<ActorAnimationParam> animationParams;

        [Space(5.0f)]
        public UnityEvent onHeal;
        public UnityEvent onHurt;
        public UnityEvent onDead;

        private void Reset()
        {
            animationParams = new List<ActorAnimationParam>();

            animationParams.Add(new ActorAnimationParam { paramName = "Health", paramHash = Animator.StringToHash("Health") });
            animationParams.Add(new ActorAnimationParam { paramName = "Damage", paramHash = Animator.StringToHash("Damage") });
            animationParams.Add(new ActorAnimationParam { paramName = "Dead", paramHash = Animator.StringToHash("Dead") });

            onHeal = new UnityEvent();
            onHurt = new UnityEvent();
            onDead = new UnityEvent();
        }

        private void Awake()
        {
            animationParams = animationParams ?? new List<ActorAnimationParam>();

            onHeal = onHeal ?? new UnityEvent();
            onHurt = onHurt ?? new UnityEvent();
            onDead = onDead ?? new UnityEvent();
        }
    }
}