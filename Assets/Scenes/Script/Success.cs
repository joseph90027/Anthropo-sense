using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success : MonoBehaviour
{
    public GameObject success;

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    public Sprite ten;
    public Sprite ensure;

    public HB_Unit_Health script;

    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (script.mSlider.value >= 0f && script.mSlider.value < 0.1f)
        { success.GetComponent<Image>().sprite = zero; }

        else if (script.mSlider.value >= 0.1f && script.mSlider.value < 0.2f)
        { success.GetComponent<Image>().sprite = one; }

        else if (script.mSlider.value >= 0.2f && script.mSlider.value < 0.3f)
        { success.GetComponent<Image>().sprite = two; }

        else if (script.mSlider.value >= 0.3f && script.mSlider.value < 0.4f)
        { success.GetComponent<Image>().sprite = three; }

        else if (script.mSlider.value >= 0.4f && script.mSlider.value < 0.5f)
        { success.GetComponent<Image>().sprite = four; }

        else if (script.mSlider.value >= 0.5f && script.mSlider.value < 0.6f)
        { success.GetComponent<Image>().sprite = five; }

        else if (script.mSlider.value >= 0.6f && script.mSlider.value < 0.7f)
        { success.GetComponent<Image>().sprite = six; }

        else if (script.mSlider.value >= 0.7f && script.mSlider.value < 0.8f)
        { success.GetComponent<Image>().sprite = seven; }

        else if (script.mSlider.value >= 0.8f && script.mSlider.value < 0.9f)
        { success.GetComponent<Image>().sprite = eight; }

        else if (script.mSlider.value >= 0.9f && script.mSlider.value < 0.95f)
        { success.GetComponent<Image>().sprite = nine; }

        else if (script.mSlider.value >= 0.95f && script.mSlider.value <= 1f)
        { success.GetComponent<Image>().sprite = ten; }
    }
}
