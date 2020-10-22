using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHome : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        RotateTurret();
    }

	private void RotateTurret()
	{
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
	}
}
