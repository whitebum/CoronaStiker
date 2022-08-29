using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public interface IHurtable
    {
        void GetHurt();
        void GetDamage();
    }
}