using CoronaStriker.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Utils
{
    [RequireComponent(typeof(Animator))]
    public class ObjectGraphics : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private Dictionary<string, AnimationParam> _animationParams;

        public Animator animator
        {
            get { return _animator; }
        }

        public Dictionary<string, AnimationParam> animationParams
        {
            get
            {
                if (_animationParams == null)
                    _animationParams = new Dictionary<string, AnimationParam>();

                return _animationParams;
            }
        }

        private void Reset()
        {
            _animator = GetComponent<Animator>();
        }

        public void AddParam(string paramName)
        {
            if (_animationParams == null)
                _animationParams = new Dictionary<string, AnimationParam>();

            animationParams.Add(paramName, new AnimationParam { paramName = paramName, paramHash = Animator.StringToHash(paramName) });
        }

        public void SetTrigger(string paramName)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                animator?.SetTrigger(animationParams[paramName]);
        }

        public void ResetTrigger(string paramName)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                animator?.ResetTrigger(animationParams[paramName]);
        }

        public void SetInteger(string paramName, int value)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                animator?.SetInteger(animationParams[paramName], value);
        }

        public int GetInteger(string paramName)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                return animator?.GetInteger(animationParams[paramName]) ?? 0;

            return 0;
        }

        public void SetFloat(string paramName, float value)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                animator?.SetFloat(animationParams[paramName], value);
        }

        public float GetFloat(string paramName)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                return animator?.GetFloat(animationParams[paramName]) ?? 0;

            return 0;
        }

        public void SetBool(string paramName, bool value)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                animator?.SetBool(animationParams[paramName], value);
        }

        public bool GetBool(string paramName)
        {
            if (animationParams?.ContainsKey(paramName) == true)
                return animator?.GetBool(animationParams[paramName]) ?? false;

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