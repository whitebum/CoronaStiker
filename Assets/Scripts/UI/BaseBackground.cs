using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public abstract class BaseBackground : CanvasHandler
    {
        public ObjectGraphics graphics;

        protected override void Reset()
        {
            base.Reset();

            graphics = GetComponentInChildren<ObjectGraphics>();

            canvas.sortingLayerName = "Background";
            canvas.sortingLayerID = SortingLayer.GetLayerValueFromName("Background");
            canvas.sortingOrder = 0;
        }
    }
}