using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectile;

    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            /*Vector3 targetPostition = new Vector3(targetEnemy.position.x,
                                        objectToPan.transform.position.y,
                                        targetEnemy.position.z);
            objectToPan.LookAt(targetPostition);*/
            objectToPan.LookAt(targetEnemy);
            Shooting(IsInRange());
        }
        else
        {
            Shooting(false);
        }

        
    }
    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyMoveTo>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyMoveTo testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }
    private Transform GetClosest (Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }
    private bool IsInRange()
    {
        float distanceToTarget = Vector3.Distance(targetEnemy.transform.position, objectToPan.transform.position);
        if (distanceToTarget <= attackRange)
        {
            return true;
        }
        return false;
    }
    private void Shooting(bool v)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = v;
    }
}
