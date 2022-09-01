using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [CreateAssetMenu(fileName = "New Virus Data", menuName = "Actor Data/Virus Data", order = int.MaxValue)]
    public class VirusData : ActorData
    {
        public int maxHP = 5;
        public float moveSpeed = 10.0f;

        [Space(5.0f)]
        public float attackTime = 0.05f;
        public Bullet[] useBullet;

        [Space(5.0f)]
        public float giveExperience;
        public float lostCurePoint;
    }
}