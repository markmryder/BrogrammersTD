using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCinema : MonoBehaviour
{

    private List<Node> path;
    [SerializeField] Camera main;
    [SerializeField] Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        TraverseMaze();
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
        main.enabled = false;
        BFSPath pathfinder = FindObjectOfType<BFSPath>();
        path = pathfinder.GetBestPath();
        print(path.Count);
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
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 250f * Time.deltaTime);

                yield return null;

            } while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f);

            //move now
            while (Vector3.Distance(transform.position, adjustedTarget) > 30f * Time.deltaTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, adjustedTarget, 50f * Time.deltaTime);
                yield return 0;
            }
            transform.position = adjustedTarget;
        }
        main.enabled = true;
        camera.enabled = false;
    }


}
