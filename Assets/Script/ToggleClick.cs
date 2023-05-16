using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleClick : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    public void whenButtonClicked()
    {
        if(UI.activeInHierarchy == true)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }
}
