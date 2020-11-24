using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyEffect : MonoBehaviour {


	private AudioSource audioSource;
	[SerializeField] List<AudioClip> clips;

	void Start()
	{
		//Random rand = new Random();
		System.Random rand = new System.Random();
		int clipNum = rand.Next(0, clips.Count);
		
		StartCoroutine(KillParticle());
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = clips[clipNum];
		audioSource.Play();
	}

	private IEnumerator KillParticle()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
