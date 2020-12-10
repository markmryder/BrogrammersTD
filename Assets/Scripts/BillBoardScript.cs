/*
 Created by: Mark Ryder
 Contributions:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardScript : MonoBehaviour
{

    public Transform camera;


	private void Start()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
