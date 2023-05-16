using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject optionsMenu;
    private UnityEngine.UI.Image image;



    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        //optionsMenu.
    }
    private void Start()
    {
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Reverse the active state every time escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check whether it's active / inactive 
            bool isActive = optionsMenu.activeSelf;

            optionsMenu.SetActive(!isActive);
        }
    }

    



}
