using Assets.Scripts.Core.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerParameter playerParam;

        [SerializeField] private ActorGraphics graphics;
        [SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerMovement move;

        private void Reset()
        {
            health = GetComponent<PlayerHealth>();
            move = GetComponent<PlayerMovement>();
        }
    }
}