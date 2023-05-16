using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB_Healthbar_BG_Scaler : MonoBehaviour
{
    public float num1 = 1;
    public float num2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1.1f + (transform.parent.localScale.x * num1 * num2), transform.localScale.y, transform.localScale.z);
    }
}
