using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private const string RUN_PARAMETER = "isRun";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void RunAnimation(bool isRun)
    {
        animator.SetBool(RUN_PARAMETER, isRun);
    }
}
