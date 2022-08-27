using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public abstract class ActorMove : MonoBehaviour
    {
        protected ActorController controller;

        private void Reset()
        {
            controller = GetComponentInParent<ActorController>();
        }

        private void Awake()
        {
            controller = controller ?? GetComponentInChildren<ActorController>();
        }
    }
}
