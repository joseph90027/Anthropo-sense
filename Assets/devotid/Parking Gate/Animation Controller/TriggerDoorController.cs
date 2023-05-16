using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
[SerializeField] private Animator myDoor = null;
[SerializeField] private bool openTrigger = false;
[SerializeField] private bool closeTrigger = false;

    public CookieNumber Script;

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        if (openTrigger)
        {
            if(Script.cookieNum >= 20)
            {
                 myDoor.Play("GateOpen", 0, 0.0f);
                 gameObject.SetActive(false);
                 Debug.Log("Open");
            }

        }

        else if (closeTrigger)
        {
            myDoor.Play("GateClose",0,0.0f);
            gameObject.SetActive(false);
        }
    }
}


}
