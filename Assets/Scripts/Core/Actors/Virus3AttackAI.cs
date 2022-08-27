using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public sealed class Virus3AttackAI : VirusAttackAI
    {
        protected override void Attack(float deltaTime)
        {
            for (int radius = 0; radius <= 360; radius += 30)
            {
                var newBullet = factory.GetBullet();

                newBullet.transform.Rotate(Quaternion.Euler(0.0f, 0.0f, radius).eulerAngles);
            }
        }
    }
}