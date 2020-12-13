/*
 Created by: Mark Ryder
 Contributions:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWobble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
    Vector3 StartPosition;

    void Update()
    {
        transform.position = new Vector3(StartPosition.x, (Mathf.Sin(Time.time * speed) * amount) + StartPosition.y, StartPosition.z);
    }
}
