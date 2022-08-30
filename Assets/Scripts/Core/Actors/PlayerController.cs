using Assets.Scripts.Core.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerController : ActorController
    {
        [SerializeField] private float maxHP;
        [SerializeField] private float moveSpeed;

        [SerializeField] private int level;

        [SerializeField] private float attackIntervalTime;
        [SerializeField] private Bullet[] bullets;

        [SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerMove move;
    }
}