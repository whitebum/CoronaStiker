using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class Bullet : MonoBehaviour
    {
        public void Update()
        {
            transform.Translate(20.0f * Time.deltaTime * Vector3.up);
        }
    }
}