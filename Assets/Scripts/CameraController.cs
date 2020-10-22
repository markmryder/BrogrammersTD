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
		if (Input.GetKey(KeyCode.D))
		{
			if (camera.transform.position.x <= maxX && camera.transform.position.z >= minZ)
			{
				camera.transform.position += new Vector3(speed * Time.deltaTime, 0, -speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			if (camera.transform.position.x >= minX && camera.transform.position.z <= maxZ)
			{
				camera.transform.position += new Vector3(-speed * Time.deltaTime, 0, speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.W))
		{
			if (camera.transform.position.z <= maxZ && camera.transform.position.x <= maxX)
			{
				camera.transform.position += new Vector3(speed * Time.deltaTime, 0, speed * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if (camera.transform.position.z >= minZ && camera.transform.position.x >= minX)
			{
				camera.transform.position += new Vector3(-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
			}
		}
	}
}
