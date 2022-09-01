using CoronaStriker.Core.Actors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Actors
{
    [CreateAssetMenu(fileName = "New Player Parameter", menuName = "Actor Parameter/Player Parameter", order = int.MaxValue)]
    public class PlayerData : ActorData
    {
        public int maxHP = 5;
        public float moveSpeed = 10.0f;

        [Space(5.0f)]
        public int maxLevel = 5;
        public float[] exp = 
        {
            100.0f,
            200.0f,
            300.0f,
            400.0f,
            500.0f,
        };
        public float attackTime = 0.05f;

        [Space(5.0f)]
        public Bullet[] useBullet;
    }
}
