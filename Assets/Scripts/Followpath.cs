using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followpath : MonoBehaviour
{
    Transform goal;

    public float speed = 5.0f;
    public float accuracy = 0.05f;
    public float rotSpeed = 0.2f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    void Start()
    {
   
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

  
    public void GoToHeli()
    {
        g.AStar(currentNode, wps[4]);
        currentWP = 0;
    }

 
    public void GoToRuin()
    {
        g.AStar(currentNode, wps[7]);
        currentWP = 0;
    }

    
    public void GoToFactory()
    {
        g.AStar(currentNode, wps[8]);
        currentWP = 0;
    }

    void LateUpdate()
    {
        if (g.getPathLength() == 0 || currentWP == g.getPathLength()) return;

        currentNode = g.getPathPoint(currentWP);

        
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        {
            currentWP++;
        }

        
        if (currentWP < g.getPathLength())
        {

            goal = g.getPathPoint(currentWP).transform;


            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);


            Vector3 direction = lookAtGoal - this.transform.position;

  
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
