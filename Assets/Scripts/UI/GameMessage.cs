using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessage : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Space(5.0f)]
    [SerializeField] private float waitTime;
    [SerializeField] private bool isShouldDisable = true;

    [Space(5.0f)]
    [SerializeField] private string openTriggerName = "Open";
    private int openTriggerHash;
    [SerializeField] private string closeTriggerName = "Close";
    private int closeTriggerHash;

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        animator = animator ?? GetComponent<Animator>();

        openTriggerHash = Animator.StringToHash(openTriggerName);
        closeTriggerHash = Animator.StringToHash(closeTriggerName);
    }

    private void Start()
    {
        StartCoroutine(TestMessageCoroutine());
    }

    public void TestMessage()
    {
        gameObject.SetActive(true);

        StartCoroutine(TestMessageCoroutine());
    }

    public IEnumerator TestMessageCoroutine()
    {
        animator.SetTrigger(openTriggerHash);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        if (isShouldDisable)
        {
            yield return new WaitForSeconds(waitTime);

            animator.SetTrigger(closeTriggerHash);

            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            gameObject.SetActive(false);
        }
    }
}
