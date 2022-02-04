using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAnimationController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void setInteger(int num)
    {
        animator.SetInteger("DisplayChangeState", num);
    }
}
