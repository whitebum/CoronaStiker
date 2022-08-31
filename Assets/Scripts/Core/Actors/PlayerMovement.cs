using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerController controller;

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
            Move();
        }

        private void Move()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            var moveDir = controller.playerParam.moveSpeed * Time.deltaTime * new Vector3(horizontal, vertical, 0.0f);
            controller.transform.position += moveDir;
        }
    }
}