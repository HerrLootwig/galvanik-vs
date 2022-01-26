using UnityEngine;
using UnityEngine.Events;

namespace haw.unitytutorium.w21
{
    [System.Serializable]
    public struct Interaction
    {
        public GameObject GameObject;
        public string Instruction;
        public string HelpMsg;
        public string ErrorMsg;
        public float duration;
        public UnityEvent Response;
    }
}