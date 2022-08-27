using CoronaStriker.Core.Actors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Actors
{
    [CreateAssetMenu(fileName = "New Player Parameter", menuName = "Actor Parameter/Player Parameter", order = int.MaxValue)]
    public class PlayerParameter : ActorParameter
    {
        public int maxLevel;

        public float attackSpeed;
        public Bullet[] useBullet;
    }
}
