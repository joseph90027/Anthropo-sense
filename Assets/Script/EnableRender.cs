using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRender : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

}
