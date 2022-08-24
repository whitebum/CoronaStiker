using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class ActorGraphics : MonoBehaviour
    {
        [Tooltip("액터의 Sprite Renderer")]
        public SpriteRenderer spriteRenderer;
        [Tooltip("액터의 Animator")]
        public Animator animator;

        private void Reset()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            spriteRenderer = spriteRenderer ?? GetComponent<SpriteRenderer>();
            animator = animator ?? GetComponent<Animator>();
        }
    }
}