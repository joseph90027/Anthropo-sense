using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Tower_Targetting : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject turretHead;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies[0] != null)
        {
            turretHead.transform.LookAt(enemies[0].transform.position);
            timer += Time.deltaTime;
            if (timer > .3f)
            {
                enemies[0].GetComponent<HB_Unit_Health>().AddPoint(3);
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enemies.Contains(other.gameObject) && other.GetComponent<HB_Unit_Health>())
        {
            enemies.Add(other.gameObject);
        }
    }
}
