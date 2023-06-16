using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// Criar struct para conter todas as variaveis dos Links (conexões)
public struct Link
{
    public enum direction { UNI, BI }   // Enum para definir direção do link
    public GameObject node1;            // 1° node do link
    public GameObject node2;            // 2° node do link
    public direction dir;               // variavel para pegar a direção link
}

public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();

    private void Start()
    {

        if (waypoints.Length > 0)
        {

            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }

            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
      
                if (l.dir == Link.direction.BI)
                {
                    graph.AddEdge(l.node2, l.node1);
                }
            }
        }
    }

    private void Update()
    {

        graph.debugDraw();
    }
}
