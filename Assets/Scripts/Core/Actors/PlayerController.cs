using Assets.Scripts.Core.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.Core.Actors
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData playerParam;

        [Space(5.0f)]
        [SerializeField] private ActorGraphics graphics;
        
        [Space(5.0f)]
        [SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerMovement move;

        private void Reset()
        {
            health = GetComponent<PlayerHealth>();
            move = GetComponent<PlayerMovement>();
        }
    }
}