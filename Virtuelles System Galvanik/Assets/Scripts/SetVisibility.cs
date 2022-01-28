using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    public Renderer rend;
    [SerializeField] public bool visibleOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = visibleOnStart;
    }

    public void visible()
    {
        rend.enabled = true;
    }

    public void invisible()
    {
        rend.enabled = false;
    }
}
