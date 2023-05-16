using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnLoc;
    public Transform shootLeft;
    public Transform shootRight;

    public bool fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fire)
        {
            Instantiate(bullet, spawnLoc.transform.position, spawnLoc.transform.rotation);
            fire = false;
        }
    }

    public void Shoot(string side)
    {
        if (side == "left")
        {
            Instantiate(bullet, shootLeft.transform.position, shootLeft.transform.rotation);
        }
        if (side == "right")
        {
            Instantiate(bullet, shootRight.transform.position, shootRight.transform.rotation);
        }
    }
}
