/*
 Created by: Mark Ryder
 Contributions:
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField][Range(1,50)] float speed;
    private float maxX, maxZ,minX,minZ;
    
    // Start is called before the first frame update
    void Start()
    {
        maxX = camera.transform.position.x + 200f;
        maxZ = camera.transform.position.z + 100f;
        minX = camera.transform.position.x;
        minZ = camera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
	{
		MoveCamera();
	}

	

	private void MoveCamera()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (camera.transform.position.x <= maxX && camera.transform.position.z >= minZ)
			{
				camera.transform.position += new Vector3(speed * Time.deltaTime, 0, -speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (camera.transform.position.x >= minX && camera.transform.position.z <= maxZ)
			{
				camera.transform.position += new Vector3(-speed * Time.deltaTime, 0, speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			if (camera.transform.position.z <= maxZ && camera.transform.position.x <= maxX)
			{
				camera.transform.position += new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			if (camera.transform.position.z >= minZ && camera.transform.position.x >= minX)
			{
				camera.transform.position += new Vector3(-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
			}
		}

		//testing mouse movement below

		float sensitivity = 40f;
		if(Input.mousePosition.x > Screen.width - sensitivity)
		{
			if (camera.transform.position.x <= maxX && camera.transform.position.z >= minZ)
			{
				camera.transform.position += new Vector3(speed * Time.deltaTime, 0, -speed * Time.deltaTime);
			}
		}
		if (Input.mousePosition.x < sensitivity)
		{
			if (camera.transform.position.x >= minX && camera.transform.position.z <= maxZ)
			{
				camera.transform.position += new Vector3(-speed * Time.deltaTime, 0, speed * Time.deltaTime);
			}
		}
		if(Input.mousePosition.y > Screen.height - sensitivity)
		{
			if (camera.transform.position.z <= maxZ && camera.transform.position.x <= maxX)
			{
				camera.transform.position += new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime);
			}
		}
		if(Input.mousePosition.y < sensitivity)
		{
			if (camera.transform.position.z >= minZ && camera.transform.position.x >= minX)
			{
				camera.transform.position += new Vector3(-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
			}
		}


	}
}
