using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 3;

    public HealthBarScript HealthBar;

    private Animator anim;
    public ThirdPersonCharacter character;
    private CapsuleCollider collider;
    private EnemyMoveTo mover;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        character = gameObject.GetComponent<ThirdPersonCharacter>();
        collider = gameObject.GetComponent<CapsuleCollider>();
        mover = gameObject.GetComponent<EnemyMoveTo>();
        SetStats();
        HealthBar.SetMaxHealth(hitPoints);
    }

    private void SetStats()
	{
        hitPoints += WaveStats.Wave;
        var agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = 0.8f + ((WaveStats.Wave - 1) *(0.05f));
	}

    private void OnParticleCollision()
    {
        hitPoints = hitPoints - 1;
        HealthBar.SetHealth(hitPoints);
        if (hitPoints == 0)
        {
            anim.SetBool("DeathTrigger", true);
            StartCoroutine(WaitForDeath());
            Destroy(mover);
            Destroy(character);
            Destroy(collider);
        }
    }
    private IEnumerator WaitForDeath()
	{
        var wave = GameObject.FindObjectOfType<WaveManager>();
        wave.AddToScore();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
	}
}
