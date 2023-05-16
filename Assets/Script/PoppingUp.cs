using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppingUp : MonoBehaviour
{
    public GameObject originalGameObject;
    private int childCount;
    //private List<int> myList = new List<int>();
    private int currentListIndex = 0; // current index of the list being printed
    private bool isPrinting = false; // flag to indicate if the coroutine is currently printing


    private void Start()
    {
        //FindChildObjectNumber();
        //StartCoroutine(PrintListCoroutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isPrinting) // check for input and if the coroutine is not already running
        {
            StartCoroutine(PrintListCoroutineByButton());
        }
    }

    public void FindChildObjectNumber()
    {
        childCount = originalGameObject.transform.childCount;
        Debug.Log(childCount + "!!!!!!!!!!!!!");

        for(int i = 0; i < childCount; i++)
        {
            GameObject child = originalGameObject.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }
    }

    IEnumerator PrintListCoroutine()
    {
        childCount = originalGameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            //Debug.Log(i);
            GameObject child = originalGameObject.transform.GetChild(i).gameObject;
            if(child.activeSelf == false)
            {
                child.SetActive(true);
            }
            
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator PrintListCoroutineByButton()
    {
        isPrinting = true; // set the flag to indicate that the coroutine is running
        childCount = originalGameObject.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            GameObject child = originalGameObject.transform.GetChild(i).gameObject;
            if (child.activeSelf == false)
            {
                child.SetActive(true);
            }
            yield return new WaitForSeconds(0.05f); // wait for 1 second before printing the next item
        }

        /*
        currentListIndex++; // move to the next list
        if (currentListIndex >= childCount) // check if we have printed all the lists
        {
            currentListIndex = 0; // reset the index
        }
        */

        isPrinting = false; // set the flag to indicate that the coroutine has finished running
    }

}
