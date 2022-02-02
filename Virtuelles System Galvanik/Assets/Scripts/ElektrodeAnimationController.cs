using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElektrodeAnimationController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void setTrue(string input)
    {
        animator.SetBool(input, true);
    }

    public void SetFalse(string input)
    {
        animator.SetBool(input, false);
    }

    public void setInteger(int num)
    {
        animator.SetInteger("changeState", num);
    }
}
