using Assets.Scripts.Core.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerController : ActorController
    {
        [SerializeField] private PlayerHealth health;
        [SerializeField] private ActorMove move;
    }
}