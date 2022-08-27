using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class Virus2AttackAI : VirusAttackAI
    {
        private Transform target;

        protected override void Attack(float deltaTime)
        {
            IsNullTarget();

            var dir = target.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var newBullet = factory.GetBullet();

            newBullet.transform.rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);
        }

        private void IsNullTarget()
        {
            if (!target)
            {
                target = FindObjectOfType<PlayerController>().transform;
            }
        }
    }
}
