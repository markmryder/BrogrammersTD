using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCinema : MonoBehaviour
{

    private List<Node> path;

    // Start is called before the first frame update
    void Start()
    {
        BFSPath pathfinder = FindObjectOfType<BFSPath>();
        path = pathfinder.GetBestPath();
        TraverseMaze();
        //store initial rotation
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TraverseMaze() 
    {

        StartCoroutine(DoRotationAtTargetDirection());
         print("done node");
        
    }

    IEnumerator DoRotationAtTargetDirection()
    {
        BFSPath pathfinder = FindObjectOfType<BFSPath>();
        path = pathfinder.GetBestPath();
        foreach (Node node in path)
		{
            Vector3 adjustedTarget = node.transform.position;
            adjustedTarget.y = adjustedTarget.y + 5;
            Quaternion targetRotation = Quaternion.identity;
            //rotate first
            do
            {              
                Vector3 targetDirection = (adjustedTarget - transform.position).normalized;
                targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100f * Time.deltaTime);

                yield return null;

            } while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f);

            //move now
            while (Vector3.Distance(transform.position, adjustedTarget) > 30f * Time.deltaTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, adjustedTarget, 30f * Time.deltaTime);
                yield return 0;
            }
            transform.position = adjustedTarget;
            Debug.Log("done node");
        }            
    }


}
