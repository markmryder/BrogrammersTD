using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTo : MonoBehaviour
{

    [SerializeField] Vector3 end; //= new Vector3(190f, 0f, 10f);
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    [SerializeField] int Hitpoints = 12;

    // Start is called before the first frame update
    void Start()
    {
        surface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(end);
    }

	public void DestroyEnemy()
	{
        Destroy(gameObject);
	}
}
