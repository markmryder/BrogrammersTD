using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;

public class TurrentPlacement : MonoBehaviour
{
    static public int totalTurret = 5;
   // [SerializeField] int totalTurrent = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnMouseOver()
    {
        print(gameObject.tag);
       // print("hello");
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Floor" && totalTurret > 0)
            {
                GameObject turrent = (GameObject)Resources.Load("Turret");
                Instantiate(turrent, transform.position, Quaternion.identity);
                totalTurret--;
            }
        }
    }
   // void Update()
   // {
        /*
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.tag);
                print(hit.point);
                print(hit.transform.position);
                if (hit.transform.tag == "Floor")
                {
                    if (totalTurrent > 0)
                    {
                        GameObject turrent = (GameObject)Resources.Load("Turret");
                        Instantiate(turrent, transform.position, Quaternion.identity);
                        //Vector3 position = hit.point;
                        //turrent.transform.position = position;
                        totalTurrent--;
                    }
                }
                if (hit.transform.name == "Head")
                {
                    Destroy(hit.transform.gameObject);
                    totalTurrent++;
                    
                }
            }
        }
        */
   // }
}
