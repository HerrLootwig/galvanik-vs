using UnityEngine;
using UnityEngine.Events;


    [System.Serializable]
    public struct WorkingStep
    {
    public GameObject currentObjekt;
    public string Instruction;
    public string description;
    //public float duration;
    public Animator animator;
    public string triggerAnimation;


    public UnityEvent Response;
}

