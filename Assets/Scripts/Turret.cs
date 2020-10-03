using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(targetEnemy.position.x,
                                        objectToPan.transform.position.y,
                                        targetEnemy.position.z);
        objectToPan.LookAt(targetPostition);
        //objectToPan.LookAt(targetEnemy);
    }
}
