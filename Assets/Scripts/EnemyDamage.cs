using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision()
    {
        hitPoints = hitPoints - 1;
        if (hitPoints < 1)
        {
            Destroy(gameObject);
        }
    }
}
