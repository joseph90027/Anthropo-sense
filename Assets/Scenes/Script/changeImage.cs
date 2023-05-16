using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    [SerializeField] 
    GameObject objectToDestroy;
    
    public Image original;
    public Sprite newSprite;
    public Sprite newSprite2;
    public Sprite newSprite3;
    public Sprite newSprite4;

    int origin = 0;

    public void NewImage() 
    {    
        origin++;
        if(origin == 1) 
        {
            original.sprite = newSprite;
        }
        if (origin == 2)
        {
            original.sprite = newSprite2;
        }
        if (origin == 3)
        {
            original.sprite = newSprite3;
        }
        if (origin == 4) 
        {
            Destroy(objectToDestroy);
            Destroy(gameObject);
        }
    }
}
