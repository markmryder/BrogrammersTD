using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	//void Update ()
	//{

	//	if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
	//	   Destroy(transform.gameObject);

	//}
	[SerializeField] AudioSource audioSource;

	void Start()
	{
		StartCoroutine(KillParticle());
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}

	private IEnumerator KillParticle()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
