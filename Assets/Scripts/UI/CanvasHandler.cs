using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

using ScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode;
using ScreenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode;

namespace CoronaStriker.UI
{
    [RequireComponent(typeof(Canvas))]
    public class CanvasHandler : MonoBehaviour
    {
        private readonly RenderMode renderMode = RenderMode.ScreenSpaceCamera;

        private readonly ScaleMode scaleMode = ScaleMode.ScaleWithScreenSize;
        private readonly Vector2 refResolution = new Vector2(1920.0f, 1080.0f);
        private readonly ScreenMatchMode screenMatchMode = ScreenMatchMode.MatchWidthOrHeight;
        private readonly float matchWidthOrHeight = 1.0f;

        [SerializeField] private Canvas m_canvas;
        [SerializeField] private CanvasScaler m_canvasScaler;

        public Canvas canvas { get => m_canvas; }
        public CanvasScaler canvasScaler { get => m_canvasScaler; }

        protected virtual void Reset()
        {
            m_canvas = GetComponent<Canvas>();
            m_canvasScaler = GetComponent<CanvasScaler>();

            m_canvas.renderMode = renderMode;
            m_canvas.worldCamera = Camera.main;

            m_canvasScaler.uiScaleMode = scaleMode;
            m_canvasScaler.referenceResolution = refResolution;
            m_canvasScaler.screenMatchMode = screenMatchMode;
            m_canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
        }

        protected virtual void Awake()
        {
            if (!m_canvas)
            {
                m_canvas = GetComponent<Canvas>();

                m_canvas.renderMode = renderMode;
                m_canvas.worldCamera = Camera.main;
            }

            if (!m_canvasScaler)
            {
                m_canvasScaler = GetComponent<CanvasScaler>();

                m_canvasScaler.uiScaleMode = scaleMode;
                m_canvasScaler.referenceResolution = refResolution;
                m_canvasScaler.screenMatchMode = screenMatchMode;
                m_canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
            }
        }

        protected virtual void FixedUpdate()
        {
            if (!m_canvas.worldCamera)
                m_canvas.worldCamera = Camera.main ?? null;
        }
    }
}