using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CoronaStriker.UI
{
    public class ItemSelector : MonoBehaviour
    {
        public bool isDisabled = false;

        public List<SelectableItem> selectableItems;

        [Space(5.0f)]
        [SerializeField] private SelectionCursor selectionCursor;

        [SerializeField] private int curSelected;
        [SerializeField] private int minSelectedCount;
        [SerializeField] private int maxSelectedCount;

        private void Reset()
        {
            selectableItems = new List<SelectableItem>();

            curSelected = 0;
            minSelectedCount = 0;
            maxSelectedCount = selectableItems.Count - 1;
        }

        private void OnValidate()
        {
            maxSelectedCount = selectableItems.Count - 1;
        }

        private void OnEnable()
        {
            isDisabled = false;

            UpdateCursorTransform();
        }

        private void Update()
        {
            if (!isDisabled)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    UpSelectionCursor();
                    UpdateCursorTransform();
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    DownSelectionCursor();
                    UpdateCursorTransform();
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isDisabled = true;

                    selectionCursor.Press();
                    //selectableItems[curSelected].GetComponent<Animator>().SetTrigger("Pressed");
                    selectableItems[curSelected].onSelected?.Invoke();
                }
            }
        }

        private void UpdateCursorTransform()
        {
            int idx = 0;
            foreach (var selectableItem in selectableItems)
            {
                if (idx == curSelected)
                {
                    //selectableItem.GetComponent<Animator>().SetTrigger("Selected");
                    selectionCursor.PointAtItem(selectableItem);
                }

                else
                {
                    //selectableItem.GetComponent<Animator>().SetTrigger("Normal");
                }

                idx++;
            }
        }

        private void UpSelectionCursor()
        {
            curSelected = curSelected != minSelectedCount ? curSelected -= 1 : maxSelectedCount;
        }

        private void DownSelectionCursor()
        {
            curSelected = curSelected != maxSelectedCount ? curSelected += 1 : minSelectedCount;
        }
    }
}