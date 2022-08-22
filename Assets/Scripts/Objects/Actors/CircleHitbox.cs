using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Objects.Actors
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CircleHitbox : Hitbox
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, (col as CircleCollider2D).radius);
        }
    }
}