using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WallRemove : MonoBehaviour
{
    private List<GameObject> Walls;
    private bool isGameActive = true;
    [SerializeField] NavMeshSurface surface;
    // Start is called before the first frame update
    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("Wall").ToList<GameObject>();
        StartCoroutine(RemoveBlocks());
    }

    // Update is called once per frame
    void Update()
    {
        //surface.BuildNavMesh();
    }

    public IEnumerator RemoveBlocks()
	{

		while (isGameActive)
		{
            if(Walls.Count == 0)
			{
                break;
			}
            surface.BuildNavMesh();
            yield return new WaitForSeconds(5);
            System.Random rand = new System.Random();
            int randNum = rand.Next(0, Walls.Count);
            GameObject destroyed = Walls[randNum];
            Walls.RemoveAt(randNum);
            Debug.Log(destroyed.name);
            Destroy(destroyed);
            
        }

    }
}
