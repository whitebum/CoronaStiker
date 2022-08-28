using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoronaStriker.UI
{
    public abstract class BaseViewer : MonoBehaviour
    {
        [SerializeField] protected Text label;
        [SerializeField] protected Text value;

        protected virtual void Reset()
        {
            label = transform.Find("Label").GetComponent<Text>();
            value = transform.Find("Value").GetComponent<Text>();
        }
    }
}