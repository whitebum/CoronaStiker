using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private ActorController controller;

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
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            var moveDir = controller.parameter.moveSpeed * Time.deltaTime * new Vector3(horizontal, vertical, 0.0f);

            controller.transform.position += moveDir;
        }
    }
}