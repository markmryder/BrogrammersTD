using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MoveWallsForDemo : MonoBehaviour
{

    private Vector3 position;
    [SerializeField] float speed = 1;
    [SerializeField] int maxZ, minZ;
    [SerializeField] NavMeshSurface surface;
    private List<GameObject> Walls;

    // Start is called before the first frame update
    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("Wall").ToList<GameObject>();
        
        maxZ = 80;
        minZ = 10;
    }

    // Update is called once per frame
    void Update()
    {

        foreach(GameObject wall in Walls) 
        {
            position = wall.transform.position;
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y, Mathf.PingPong(Time.time * speed, maxZ - minZ) + minZ);
        }

        
        //surface.BuildNavMesh();
    }
}
