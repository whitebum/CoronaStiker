using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public sealed class SelectionCursor : MonoBehaviour
    {
        [SerializeField] private Animator cursorAnim;

        private void Reset()
        {
            cursorAnim = GetComponent<Animator>();  
        }

        private void Awake()
        {
            cursorAnim = cursorAnim ?? GetComponent<Animator>();
        }

        public void PointAtItem(SelectableItem item)
        {
            transform.position = item.transform.position;
        }

        public void Press()
        {
            cursorAnim?.SetTrigger("Pressed");
        }

        public void Select()
        {
            cursorAnim?.SetTrigger("Selected");
        }
    }
}