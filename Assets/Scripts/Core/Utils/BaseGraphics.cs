using CoronaStriker.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Utils
{
    [RequireComponent(typeof(Animator))]
    public class BaseGraphics : MonoBehaviour
    {
        public Animator animator;

        public Dictionary<string, AnimationArgs> animationArgs;

        private void Reset()
        {
            animator = GetComponent<Animator>();
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

        public float GetCurrentAnimationLength()
        {
            return GetCurrentAnimationLength(0);
        }

        public float GetCurrentAnimationLength(int layerId)
        {
            return animator?.GetCurrentAnimatorStateInfo(0).length ?? 0.0f;
        }

        public float GetCurrentAnimationLength(string layerName)
        {
            return animator?.GetCurrentAnimatorStateInfo(animator.GetLayerIndex(layerName)).length ?? 0.0f;
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