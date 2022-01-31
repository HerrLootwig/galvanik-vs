using UnityEngine;
using UnityEngine.Events;


    [System.Serializable]
    public struct WorkingStep
    {
        public GameObject GameObject;
        public string Instruction;
        public float duration;

        public UnityEvent Response;
}

