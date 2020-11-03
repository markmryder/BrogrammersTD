﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 3;

    private Animator anim;
    public ThirdPersonCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        character = gameObject.GetComponent<ThirdPersonCharacter>();
    }

    private void OnParticleCollision()
    {
        hitPoints = hitPoints - 1;
        if (hitPoints == 0)
        {
            anim.SetBool("DeathTrigger", true);        
            StartCoroutine(WaitForDeath());
        }
    }
    private IEnumerator WaitForDeath()
	{
        WaveStats.AddToScore();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
	}
}
