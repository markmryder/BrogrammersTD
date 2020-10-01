using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSPath : MonoBehaviour
{
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    [SerializeField] Node startNode, endNode;

    Queue<Node> queue = new Queue<Node>();
    bool isRunning = true;

    Node searchCenter;

    public List<Node> path = new List<Node>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    private void CreatePath()
    {
        path.Add(endNode);

        Node exploredFrom = endNode.exploredFrom;
        while (exploredFrom != startNode)
        {
            path.Add(exploredFrom);
            exploredFrom = exploredFrom.exploredFrom;
        }
        path.Add(startNode);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startNode);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            if (searchCenter == endNode)
            {
                isRunning = false;
            }
            ExploreNeighbour();
            searchCenter.isExplored = true;

        }
    }


    private void ExploreNeighbour()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Node neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }


    }


    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Node>();
        foreach (Node waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            var gridPosition = waypoint.GetGridPos();
            if (isOverlapping)
            {
                Debug.LogWarning("Skipping duplicate block at: " + waypoint);
            }
            else
            {
                grid.Add(gridPosition, waypoint);
            }

        }
    }

    public List<Node> GetBestPath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
