﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{


    public AudioMixer mixer;

	private void Start()
	{
		
	}


	public void SetLevel(float volume)
	{
        mixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
	}

}
