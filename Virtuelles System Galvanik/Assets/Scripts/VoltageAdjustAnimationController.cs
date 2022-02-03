using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltageAdjustAnimationController : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void setInteger(int num)
    {
        animator.SetInteger("changeStateNetzgerät", num);
    }
}
