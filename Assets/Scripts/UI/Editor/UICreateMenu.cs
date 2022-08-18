using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

namespace CoronaStriker.UI.Editor
{
    public static class UICreateMenu
    {
        private static void HandleCreateContext(MenuCommand menuCommand, GameObject createdObject)
        {
            // 부모 오브젝트 설정
            GameObjectUtility.SetParentAndAlign(createdObject, menuCommand.context as GameObject);
            // Undo 스택에 Push
            Undo.RegisterCreatedObjectUndo(createdObject, $"Create {createdObject.name}");
            Selection.activeObject = createdObject;
        }

        private static GameObject CreateCloneByPrefab(string prefabPath)
        {
            var loadedPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var createdClone = Object.Instantiate(loadedPrefab);

            return createdClone;
        }

        private static string customCanvasPath = "Assets/Prefabs/UI Basements/Canvas.prefab";
        private static string customCanvasName = "Custom Canvas";

        private static string eventSystemPath = "Assets/Prefabs/UI Basements/EventSystem.prefab";
        private static string eventSystemName = "EventSystem";  

        [MenuItem("GameObject/UI/Custom Canvas")]
        private static void CreateCustomCanvas(MenuCommand menuCommand)
        {
            var newCanvas = CreateCloneByPrefab(customCanvasPath);
            newCanvas.name = customCanvasName;

            HandleCreateContext(menuCommand, newCanvas);

            if (!Object.FindObjectOfType<EventSystem>())
            {
                var newEventSystem = CreateCloneByPrefab(eventSystemPath);
                newEventSystem.name = eventSystemName;

                HandleCreateContext(menuCommand, newEventSystem);
            }
        }

        private static string fadeableImagePath = "Assets/Prefabs/UI Basements/Fadeable Image.prefab";
        private static string fadeableImageName = "Fadeable Image";

        [MenuItem("GameObject/UI/Fadeable Image")]
        private static void CreateFadeableImage(MenuCommand menuCommand)
        {
            var newFadeableImage = CreateCloneByPrefab(fadeableImagePath);
            newFadeableImage.name = fadeableImageName;

            HandleCreateContext(menuCommand, newFadeableImage);
        }

        private static string fadeableTextPath = "Assets/Prefabs/UI Basements/Fadeable Text.prefab";
        private static string fadeableTextName = "Fadeable Text";

        [MenuItem("GameObject/UI/Fadeable Text")]
        private static void CreateFadeableText(MenuCommand menuCommand)
        {
            var newFadeableText = CreateCloneByPrefab(fadeableTextPath);
            newFadeableText.name = fadeableTextName;

            HandleCreateContext(menuCommand, newFadeableText);
        }

        private static string menuPanelPath = "Assets/Prefabs/UI Basements/Menu Panel.prefab";
        private static string menuPanelName = "New Menu Panel";

        [MenuItem("GameObject/UI/Menu Panel")]
        private static void CreateMenuPanel(MenuCommand menuCommand)
        {
            var newMenuPanel = CreateCloneByPrefab(menuPanelPath);
            newMenuPanel.name = menuPanelName;

            HandleCreateContext(menuCommand, newMenuPanel);
        }

        private static string recordViewerPath = "Assets/Prefabs/UI Basements/Record Viewer.prefab";
        private static string recordViewerName = "New Record Viewer";

        [MenuItem("GameObject/UI/Record Viewer")]
        private static void CreateRecordViewer(MenuCommand menuCommand)
        {
            var newRecordViewer = CreateCloneByPrefab(recordViewerPath);
            newRecordViewer.name = recordViewerName;

            HandleCreateContext(menuCommand, newRecordViewer);
        }
    }
}
