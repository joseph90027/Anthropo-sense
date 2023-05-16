using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyFind : MonoBehaviour {
    
    private Text exclamation;

    public Color initialColor;
    public Color switchColor;
    Image image;

    void Awake()
    {
        exclamation = this.transform.Find("ExCanvas/ExclamationText").GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        image = GetComponentInChildren<Image>();
        image.color = initialColor;
        //print(image.color);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        exclamation.enabled = true;
        if (other.gameObject.tag == "Player")
        {
            print("detected");
            
            image.color = switchColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        exclamation.enabled = false;
        if (other.gameObject.tag == "Player")
        {
            
            image.color = initialColor;
        }
    }


}
