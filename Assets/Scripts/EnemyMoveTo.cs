using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyMoveTo : MonoBehaviour
{

    [SerializeField] Vector3 end; //= new Vector3(190f, 0f, 10f);
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    [SerializeField] int Hitpoints = 12;
    
    public ThirdPersonCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        //surface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
        surface = GameObject.Find("World").GetComponent<NavMeshSurface>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(end);
        

        if(agent.remainingDistance > agent.stoppingDistance) 
        {
            character.Move(agent.desiredVelocity, false, false);
        }
		else
		{
            character.Move(Vector3.zero, false, false);
		}
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
            print("Trying to ignore collision");
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<CapsuleCollider>());
		}
	}

	public void DestroyEnemy()
	{
        Destroy(gameObject);
	}
}
