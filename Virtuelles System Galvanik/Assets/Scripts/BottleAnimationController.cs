using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAnimationController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    public void SetActive()
    {
        animator.SetBool("Activate", true);
    }

    public void SetInactive()
    {
        animator.SetBool("Activate", false);
    }
}
