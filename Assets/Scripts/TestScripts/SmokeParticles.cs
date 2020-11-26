using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopParticles());
    }


    private IEnumerator StopParticles()
	{
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
	}
}
