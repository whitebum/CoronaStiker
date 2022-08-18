using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public sealed class HowToPlayPanel : BasePanel
    {
        [SerializeField] private Transform[] panelCollection;
        [SerializeField] private ItemSelector  itemSelector;

        protected override void Awake()
        {
            base.Awake();

            itemSelector.selectableItems[0].onSelected.AddListener(() => panelCollection[0].gameObject.SetActive(true));
            itemSelector.selectableItems[1].onSelected.AddListener(() => panelCollection[1].gameObject.SetActive(true));
            itemSelector.selectableItems[2].onSelected.AddListener(() => panelCollection[2].gameObject.SetActive(true));
        }

        protected override void Reset()
        {
            base.Reset();
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (var panel in panelCollection)
                {
                    if (panel.gameObject.activeSelf)
                    {
                        panel.gameObject.SetActive(itemSelector.isDisabled = false);
                        return;
                    }
                }

                ClosePanel();
            }
        }
    }
}