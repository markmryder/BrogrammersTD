﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    [SerializeField]public int Hitpoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        //Debug.Log("hit");
        print("Destroy person");
        Destroy(other.gameObject);
        Hitpoints--;
        if(Hitpoints < 0)
		{
            Hitpoints = 0;
		}
	}
}
