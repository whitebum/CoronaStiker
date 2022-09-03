using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public struct ActorLayerLevel
    {
        #region Layer Name
        public const string actorLayerName = "Actor";
        #endregion

        #region Layer ID
        #region Dummy ID
        public const int defalutID = 0;
        #endregion

        #region Viruses' ID
        public const int enemy1Level = 0;
        public const int enemy2Level = 1;
        public const int enemy3Level = 2;
        #endregion

        #region Cells' ID
        public const int redCellLevel = 3;
        public const int whiteCellLevel = 4;
        #endregion

        #region Player's ID
        public const int playerLevel = 5;
        #endregion
        #endregion
    }
}