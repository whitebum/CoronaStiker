using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    [Space(10.0f)]
    [SerializeField] private float testHP = 5.0f;

    [Space(10.0f)]
    [SerializeField] private string healthTriggerName;
    [SerializeField] private int healthTriggerHash;

    [SerializeField] private string deadTriggerName;
    [SerializeField] private int deadTriggerHash;

    [SerializeField] private string damageTriggerName;
    [SerializeField] private int damageTriggerHash;

    [SerializeField] private string idleTriggerName;
    [SerializeField] private int idleTriggerHash;

    private void Reset()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        healthTriggerName = "";
        healthTriggerHash = 0;

        deadTriggerName = "";
        deadTriggerHash = 0;

        damageTriggerName = "";
        damageTriggerHash = 0;

        idleTriggerName = "";
        idleTriggerHash = 0;
    }

    private void Awake()
    {
        healthTriggerHash = Animator.StringToHash(healthTriggerName);
        damageTriggerHash = Animator.StringToHash(damageTriggerName);
        idleTriggerHash = Animator.StringToHash(idleTriggerName);
        deadTriggerHash = Animator.StringToHash(deadTriggerName);
    }

    private void Start()
    {
        animator.SetInteger(healthTriggerHash, (int)testHP);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            testHP++;
            StartCoroutine(Flash());
            animator.SetInteger(healthTriggerHash, (int)testHP);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            testHP--;
            StartCoroutine(Flash());
            animator.SetInteger(healthTriggerHash, (int)testHP);
        }
    }

    private IEnumerator Flash()
    {
        animator.SetTrigger(damageTriggerHash);
        yield return new WaitForSecondsRealtime(6.0f);
        animator.SetTrigger(idleTriggerHash);
    }
}
