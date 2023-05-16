using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Demo_Unit_Movement : MonoBehaviour
{
    public List<Transform> waypoints;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.Find("Game_Controller").GetComponent<Demo_Waypoint_Tracker>().waypoints;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Demo_WP>())
        {
            waypoints.Remove(waypoints[0]);
            agent.destination = waypoints[0].position;
        }
    }
}
