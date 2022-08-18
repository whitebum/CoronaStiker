using CoronaStriker.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    public class MenuScene : MonoBehaviour
    {
        public MainMenuPanel mainMenuPanel;
        public SelectLevelPanel selectLevelPanel;
        public HowToPlayPanel howToPlayPanel;
        public HallOfFamePanel hallOfFamePanel;
        public SetttingConfigurePanel setttingConfigurePanel;

        private void Awake()
        {
            selectLevelPanel.onOpen.AddListener(() => mainMenuPanel.ClosePanel());
            selectLevelPanel.onClose.AddListener(() => mainMenuPanel.OpenPanel());

            howToPlayPanel.onOpen.AddListener(() => mainMenuPanel.ClosePanel());
            howToPlayPanel.onClose.AddListener(() => mainMenuPanel.OpenPanel());

            hallOfFamePanel.onOpen.AddListener(() => mainMenuPanel.ClosePanel());
            hallOfFamePanel.onClose.AddListener(() => mainMenuPanel.OpenPanel());

            setttingConfigurePanel.onOpen.AddListener(() => mainMenuPanel.ClosePanel());
            setttingConfigurePanel.onClose.AddListener(() => mainMenuPanel.OpenPanel());
        }
    }
}