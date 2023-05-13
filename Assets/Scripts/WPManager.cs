using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMANAGER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(waypoints.Lenght > 0)
        {
            foreach(GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }
            foreach(Link l in links)
        {
            graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)
                    graph.AddEdge(l.node2, l.node1);
        }
        } 
    }

    // Update is called once per frame
    void Update()
    {
    graph.debugDraw();  
    }
}
