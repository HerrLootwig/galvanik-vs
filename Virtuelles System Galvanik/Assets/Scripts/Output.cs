using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{

    [SerializeField] Animator animator;
    public void triggered() {
        animator.SetTrigger("Power On");
        Debug.Log("PAUWÖR");
    }
}
