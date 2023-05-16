using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public HB_Unit_Health script;

    public Text timerText;
    private float startTime;

    [SerializeField] public Image customImage;
    public float delay;
    private MeshRenderer[] MR;

    private string minutes;
    private string seconds;

    public int i;
    public int j;

    private IEnumerator WaitBeforeShow(Image customImage, float delay)
    {

        customImage.enabled = true;

        yield return new WaitForSeconds(delay);

        customImage.enabled = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f0");
        
        
        i = (int)t/60;
        j = (int)t % 60;


        timerText.text = minutes + ":" + seconds;

        if(i % 2 == 1 && seconds == "0" && i != 0) 
        {
            StartCoroutine(WaitBeforeShow(customImage, delay));
            
        }
    }


}
