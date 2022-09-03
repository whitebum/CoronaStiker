using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Items
{
    public struct ItemLayerLevel
    {
        #region Layer Name
        public const string itemLayerName = "Item";
        #endregion

        #region Layer ID
        public const int defaultID = 0;
        public const int healthItemID = 1;
        public const int invincibleItemID = 2;
        public const int shieldItemID = 3;
        public const int BoostItemID = 4;
        public const int RandomItemID = 5;
        #endregion
    }
}