using CoronaStriker.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ActorGraphics : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Animator animator;

        public Dictionary<string, AnimationArgs> animationArgs;

        private void Reset()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            
        }

        public void AddArg(string argName)
        {
            if (animationArgs == null) 
                animationArgs = new Dictionary<string, AnimationArgs>();

            animationArgs.Add(argName, new AnimationArgs { argName = argName, argHash = Animator.StringToHash(argName) });
        }

        public void SetTrigger(string argName)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                animator?.SetTrigger(animationArgs[argName]);
        }

        public void ResetTrigger(string argName)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                animator?.ResetTrigger(animationArgs[argName]);
        }

        public void SetInteger(string argName, int value)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                animator?.SetInteger(animationArgs[argName], value);
        }

        public int GetInteger(string argName)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                return animator?.GetInteger(animationArgs[argName]) ?? 0;

            return 0;
        }       
        
        public void SetFloat(string argName, float value)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                animator?.SetFloat(animationArgs[argName], value);
        }

        public float GetFloat(string argName)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                return animator?.GetFloat(animationArgs[argName]) ?? 0;

            return 0;
        }

        public void SetBool(string argName, bool value)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                animator?.SetBool(animationArgs[argName], value);
        }

        public bool GetBool(string argName)
        {
            if (animationArgs?.ContainsKey(argName) == true)
                return animator?.GetBool(animationArgs[argName]) ?? false;

            return false;
        }

        public int GetLayerIndex(string layerName)
        {
            return animator?.GetLayerIndex(layerName) ?? -1;
        }

        public string GetLayerName(int layerIndex)
        {
            return animator?.GetLayerName(layerIndex);
        }
    }
}