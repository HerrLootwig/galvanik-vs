using UnityEngine;
using UnityEngine.Events;


    [System.Serializable]
    public struct WorkingStep
    {
        public GameObject GameObject;
        public string Instruction;
        public float duration;
        public Animator animator;
        public string triggerAnimation;


        public UnityEvent Response;
}

