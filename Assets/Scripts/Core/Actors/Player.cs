using Assets.Scripts.Core.Actors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class Player : MonoBehaviour
    {
        public PlayerData playerData;

        public PlayerHealth health;
        public PlayerController controller;
    }
}
