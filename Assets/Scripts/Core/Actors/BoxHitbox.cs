using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BoxHitbox : Hitbox
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, (colider as BoxCollider2D).size);
        }
    }
}