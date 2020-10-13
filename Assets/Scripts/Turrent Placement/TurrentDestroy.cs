using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        //print(gameObject.tag);
        //print("hello");
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Turret")
            {
                Destroy(gameObject);
                TurrentPlacement.totalTurret++;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
