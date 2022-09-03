using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public struct UILayerLevel
    {
        #region Layer Name
        public const string uiLayerName = "UI";
        #endregion

        #region Layer ID
        public const int defaultID = 0;
        public const int playerHUDID = 1;
        public const int gameMessageID = 2;
        public const int panelID = 3;
        #endregion
    }
}