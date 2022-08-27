using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Utils
{
    public class TestMertarial : MonoBehaviour
    {
        public Material Material;

        public void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, Material);
        }
    }
}