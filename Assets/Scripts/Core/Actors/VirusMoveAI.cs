using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public abstract class VirusMoveAI : MonoBehaviour
    {
        [SerializeField] private bool isCanMove;
        [SerializeField] private float moveSpeed;

        private void Update()
        {
            if (isCanMove)
                Move();
        }

        protected abstract void Move();
    }
}