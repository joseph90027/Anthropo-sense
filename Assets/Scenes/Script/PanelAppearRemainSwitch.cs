using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAppearRemainSwitch : MonoBehaviour
{
    [SerializeField] private Image customImageSuccess;
    [SerializeField] private Image customImageFail;
    public float delay;
    private Renderer rend;
    private GameObject cat;
    private MeshRenderer[] MR;

    public GameObject gameOBject;
    public CookieNumber script;

    public float cookieMinimum;
    private IEnumerator WaitBeforeShow(Image customImage, float delay)
    {

        customImage.enabled = true;

        yield return new WaitForSeconds(delay);

        customImage.enabled = false;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if(script.cookieNum >= 20f)
            {
                StartCoroutine(WaitBeforeShow(customImageSuccess, delay));
            }

            if (script.cookieNum < 20f)
            {
                StartCoroutine(WaitBeforeShow(customImageFail, delay));
            }
        }


    }
}
