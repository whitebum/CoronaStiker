using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CircleHitbox : Hitbox
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, (colider as CircleCollider2D).radius);
        }
    }
}