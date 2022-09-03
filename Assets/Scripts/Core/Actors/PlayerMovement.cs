using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Effects;

namespace CoronaStriker.Core.Actors
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerController controller;

        [SerializeField] private bool isBoost;
        [SerializeField] private float boostTimer;
        [SerializeField] private KeepableEffect boostEffect;

        private void Reset()
        {
            controller = GetComponentInParent<PlayerController>();
        }

        private void Awake()
        {
            controller = controller ?? GetComponentInParent<PlayerController>();    
        }

        private void Update()
        {
            if (isBoost)
            {
                if ((boostTimer -= Time.deltaTime) <= 0.0f)
                {
                    isBoost = false;
                    boostTimer = 0.0f;

                    boostEffect.OffEffect();
                }
            }

            Move();
        }

        private void Move()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            var moveDir = (controller.playerParam.moveSpeed + (isBoost ? 5.0f : 0.0f)) * Time.deltaTime * new Vector3(horizontal, vertical, 0.0f);
            controller.transform.position += moveDir;
        }

        public void Boost(float time)
        {
            isBoost = true;
            boostTimer = time;

            boostEffect.OnEffect();
        }
    }
}