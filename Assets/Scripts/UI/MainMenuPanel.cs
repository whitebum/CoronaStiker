using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CoronaStriker.Level;

namespace CoronaStriker.UI
{
    public sealed class MainMenuPanel : BasePanel
    {
        public MenuScene temp;
        public ItemSelector menuSelector;

        protected override void Reset()
        {
            base.Reset();

            menuSelector = GetComponentInChildren<ItemSelector>();
        }

        protected override void Awake()
        {
            base.Awake();

            menuSelector.selectableItems[0].onSelected.AddListener(() =>
            {
                temp.selectLevelPanel.OpenPanel();
            });
            menuSelector.selectableItems[1].onSelected.AddListener(() =>
            {
                temp.howToPlayPanel.OpenPanel();
            });
            menuSelector.selectableItems[2].onSelected.AddListener(() =>
            {
                temp.hallOfFamePanel.OpenPanel();
            });
            menuSelector.selectableItems[3].onSelected.AddListener(() =>
            {
                temp.setttingConfigurePanel.OpenPanel();
            });
            menuSelector.selectableItems[4].onSelected.AddListener(() =>
            {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
            });
        }
    }
}